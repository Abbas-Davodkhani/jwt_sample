using Application.Model;
using Domain.Entities;

namespace Application.Contracts;

public interface IUserRepository
{
    Task<bool> IsValidUserAsync(UserLoginDto user);
    UserRefreshToken AddUserRefreshTokens(UserRefreshToken user);

    UserRefreshToken GetSavedRefreshTokens(string username, string refreshtoken);

    void DeleteUserRefreshTokens(string username, string refreshToken);
}
