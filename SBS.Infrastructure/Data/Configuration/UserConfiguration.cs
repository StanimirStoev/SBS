using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SBS.Infrastructure.Data.Models.Account;

namespace SBS.Infrastructure.Data.Configuration
{
    /// <summary>
    /// Data for seeding Users
    /// </summary>
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        /// <summary>
        /// Configure (seed) Users
        /// </summary>
        /// <param name="builder"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(CreateUsers());
        }

        private List<ApplicationUser> CreateUsers()
        {
            List<ApplicationUser> users = new List<ApplicationUser>();
            var hasher = new PasswordHasher<ApplicationUser>();

            var user = new ApplicationUser()
            {
                Id = "81762cb3-03ed-415e-a81a-4b73c9fec1fb",
                UserName = "Алекс",
                NormalizedUserName = "Алекс".ToUpper(),
                Email = "alex@mail.com",
                NormalizedEmail = "alex@mail.com".ToUpper(),
                FirstName = "Александър",
                LastName = "Нацов",
                EmailConfirmed = true,
            };
            user.PasswordHash = hasher.HashPassword(user, "!QAZ2wsx");
            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "719a59a9-fc15-49be-a5e9-6f1d6f4fdc47",
                UserName = "Ники",
                NormalizedUserName = "Ники".ToUpper(),
                Email = "nikki@mail.com",
                NormalizedEmail = "nikki@mail.com".ToUpper(),
                FirstName = "Николета",
                LastName = "Добрева",
                EmailConfirmed = true,
            };
            user.PasswordHash = hasher.HashPassword(user, "!QAZ2wsx");
            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "64c7e2a2-f704-4515-a294-13fa5e9b28a8",
                UserName = "Дидо",
                NormalizedUserName = "Дидо".ToUpper(),
                Email = "dido@mail.com",
                NormalizedEmail = "dido@mail.com".ToUpper(),
                FirstName = "Диян",
                LastName = "Христов",
                EmailConfirmed = true,
            };
            user.PasswordHash = hasher.HashPassword(user, "!QAZ2wsx");
            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "c5798b10-2d39-479f-9e29-042ed2562c3f",
                UserName = "Чефо",
                NormalizedUserName = "Чефо".ToUpper(),
                Email = "stefan@mail.com",
                NormalizedEmail = "stefan@mail.com".ToUpper(),
                FirstName = "Стефан",
                LastName = "Великов",
                EmailConfirmed = true,
            };
            user.PasswordHash = hasher.HashPassword(user, "!QAZ2wsx");
            users.Add(user);

            return users;
        }
    }
}
