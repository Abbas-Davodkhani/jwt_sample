using Application.Contracts;
using Application.Model;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IJwtService _jWTManager;
        private readonly IUserRepository _userServiceRepository;

        public UsersController(IJwtService jWTManager, IUserRepository userServiceRepository)
        {
            _jWTManager = jWTManager;
            _userServiceRepository = userServiceRepository;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate-user")]
        public async Task<IActionResult> AuthenticateAsync(UserLoginDto usersdata)
        {
            var validUser = await _userServiceRepository.IsValidUserAsync(usersdata);

            if (!validUser)
            {
                return Unauthorized("نام کاربری یا رمز عبور معتبر نیست !");
            }

            var token = _jWTManager.GenerateToken(usersdata.Email);

            if (token == null)
            {
                return Unauthorized("مشکلی رخ داد مجددا تلاش کنید !");
            }

            UserRefreshToken obj = new UserRefreshToken
            {
                RefreshToken = token.RefreshToken,
                UserName = usersdata.Email
            };

            _userServiceRepository.AddUserRefreshTokens(obj);
            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("refresh-token")]
        public IActionResult Refresh(Token token)
        {
            var principal = _jWTManager.GetPrincipalFromExpiredToken(token.AccessToken);
            var username = principal.Identity?.Name;

            var savedRefreshToken = _userServiceRepository.GetSavedRefreshTokens(username, token.RefreshToken);

            if (savedRefreshToken.RefreshToken != token.RefreshToken)
            {
                return Unauthorized("مشکلی رخ داد مجددا تلاش کنید !");
            }

            var newJwtToken = _jWTManager.GenerateRefreshToken(username);

            if (newJwtToken == null)
            {
                return Unauthorized("خطای احراز هویت");
            }

            UserRefreshToken obj = new UserRefreshToken
            {
                RefreshToken = newJwtToken.RefreshToken,
                UserName = username
            };

            _userServiceRepository.DeleteUserRefreshTokens(username, token.RefreshToken);
            _userServiceRepository.AddUserRefreshTokens(obj);

            return Ok(newJwtToken);
        }

        
    }
}