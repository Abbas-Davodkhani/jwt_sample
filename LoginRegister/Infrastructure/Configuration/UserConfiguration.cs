using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                    new User
                    {
                        Id = 1,
                        FullName = "Morgan Freeman",
                        Email = "m@gmail.com",
                        Password = "123456"
                    },
                    new User
                    {
                        Id = 2,
                        FullName = "Denzel Washington",
                        Email = "d@gmail.com",  
                        Password = "123456"
                    },
                    new User
                    {
                        Id = 3,
                        FullName = "Tom Hanks",
                        Email = "t@gmail.com",
                        Password = "123456"
                    },
                    new User
                    {
                        Id = 4,
                        FullName = "Al Pacino",
                        Email = "a@gmail.com",
                        Password = "123456"
                    },
                    new User
                    {
                        Id = 5,
                        FullName = "Samuel L. Jackson",
                        Email = "s@gmail.com",
                        Password = "123456"
                    },
                    new User
                    {
                        Id = 6,
                        FullName = "Robert Downey Jr.",
                        Email = "r@gmail.com",
                        Password = "123456"
                    },
                    new User
                    {
                        Id = 7,
                        FullName = "George Gerdes",
                        Email = "g@gmail.com",
                        Password = "123456"
                    },
                    new User
                    {
                        Id = 8,
                        FullName = "Paul Geoffrey",
                        Email = "p@gmail.com",
                        Password = "123456"
                    }
                );
        }
    }

}
