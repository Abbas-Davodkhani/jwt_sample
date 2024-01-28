using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Contracts;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    DbSet<UserRefreshToken> UserRefreshTokens { get; }
    int SaveChanges();
}
