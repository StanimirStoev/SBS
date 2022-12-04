using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SBS.Infrastructure.Data.Configuration
{
    /// <summary>
    /// Data for seeding Roles
    /// </summary>
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        /// <summary>
        /// Configure (seed) Roles
        /// </summary>
        /// <param name="builder"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(CreateRoles());
        }

        private List<IdentityRole> CreateRoles()
        {
            List<IdentityRole> roles = new List<IdentityRole>();

            var role = new IdentityRole()
            {
                Id = "1efc4197-6067-404f-8f6a-83f265237320",
                Name = "Admin",
                NormalizedName = "Admin".ToUpper(),
            };
            roles.Add(role);

            role = new IdentityRole()
            {
                Id = "73bf8f04b-bc67-43ea-9924-001bf045b149",
                Name = "Manager",
                NormalizedName = "Manager".ToUpper(),
            };
            roles.Add(role);

            return roles;
        }

    }
}
