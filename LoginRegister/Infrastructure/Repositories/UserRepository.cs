using Application.Contracts;
using Application.Model;
using Domain.Entities;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IApplicationDbContext dbContext;

    public UserRepository(IApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public UserRefreshToken AddUserRefreshTokens(UserRefreshToken user)
    {
        this.dbContext.UserRefreshTokens.Add(user);
        this.dbContext.SaveChanges();
        return user;
    }

    public void DeleteUserRefreshTokens(string username, string refreshToken)
    {
        var maybeUserRefreshToken = this.dbContext.UserRefreshTokens.FirstOrDefault(x => x.UserName == username && x.RefreshToken == refreshToken);
        if (maybeUserRefreshToken is null)
        {
            this.dbContext.UserRefreshTokens.Remove(maybeUserRefreshToken);
        }
    }

    public UserRefreshToken? GetSavedRefreshTokens(string username, string refreshToken)
    {
        return this.dbContext.UserRefreshTokens.FirstOrDefault(x => x.UserName == username && x.RefreshToken == refreshToken && x.IsActive == true);
    }

    public async Task<bool> IsValidUserAsync(UserLoginDto user)
    {
        var maybeUser = this.dbContext.Users.FirstOrDefault(o => o.Email == user.Email && o.Password == user.Password);

        if (maybeUser != null)
            return true;
        else
            return false;
    }
}
