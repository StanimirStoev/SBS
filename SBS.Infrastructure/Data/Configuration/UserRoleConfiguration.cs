using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SBS.Infrastructure.Data.Configuration
{
    /// <summary>
    /// Data for seeding Roles for Users
    /// </summary>
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        /// <summary>
        /// Configure (seed) Roles for Users
        /// </summary>
        /// <param name="builder"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(CreateUserRoles());
        }

        private List<IdentityUserRole<string>> CreateUserRoles()
        {
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();

            var userRole = new IdentityUserRole<string>()
            {
                RoleId = "1efc4197-6067-404f-8f6a-83f265237320",//Admin
                UserId = "81762cb3-03ed-415e-a81a-4b73c9fec1fb",//Алекс
            };
            userRoles.Add(userRole);

            userRole = new IdentityUserRole<string>()
            {
                RoleId = "73bf8f04b-bc67-43ea-9924-001bf045b149",//Manager
                UserId = "719a59a9-fc15-49be-a5e9-6f1d6f4fdc47",//Ники
            };
            userRoles.Add(userRole);

            return userRoles;
        }
    }
}
