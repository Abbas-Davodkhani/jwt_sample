using Application.Model;
using System.Security.Claims;

namespace Application.Contracts;

public interface IJwtService
{
    Token GenerateToken(string userName);
    Token GenerateRefreshToken(string userName);
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}
