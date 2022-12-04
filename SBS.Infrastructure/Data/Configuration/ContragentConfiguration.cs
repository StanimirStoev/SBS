using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SBS.Infrastructure.Data.Models;

namespace SBS.Infrastructure.Data.Configuration
{
    /// <summary>
    /// Data for seeding Contragents
    /// </summary>
    public class ContragentConfiguration : IEntityTypeConfiguration<Contragent>
    {
        /// <summary>
        /// Configure (seed) contragents
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Contragent> builder)
        {
            builder.HasData(CreateContragents());
        }

        private List<Contragent> CreateContragents()
        {
            List<Contragent> contragents = new List<Contragent>();

            var contragent = new Contragent()
            {
                Id = new Guid("0625109a-585a-4c4e-be30-5a18b1e311f8"),
                FirstName = "STC ltd.",
                LastName = "Smart Trusted Computers ltd.",
                VatNumber = "182681ER232",
                IsClient = true,
                IsSupplier = true,
                IsActive = true,
            };
            contragents.Add(contragent);

            contragent = new Contragent()
            {
                Id = new Guid("c85f94df-a849-42b7-a08b-e7ef758dfb43"),
                FirstName = "Kassy",
                LastName = "Chandler",
                VatNumber = "8147822135",
                IsClient = true,
                IsSupplier = false,
                IsActive = true,
            };
            contragents.Add(contragent);

            contragent = new Contragent()
            {
                Id = new Guid("e9e67ae0-84c7-4279-96fc-bf12baaea7e9"),
                FirstName = "Adrean",
                LastName = "Vasilev",
                VatNumber = "9273028735",
                IsClient = true,
                IsSupplier = false,
                IsActive = true,
            };
            contragents.Add(contragent);

            return contragents;
        }
    }
}
