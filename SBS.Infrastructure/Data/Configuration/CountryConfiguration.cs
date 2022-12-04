using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SBS.Infrastructure.Data.Models;

namespace SBS.Infrastructure.Data.Configuration
{
    /// <summary>
    /// Data for seeding countries
    /// </summary>
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        /// <summary>
        /// Configure (seed) Countries
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(CreateCountries());
        }
        private List<Country> CreateCountries()
        {
            List<Country> countries = new List<Country>();

            var country = new Country()
            {
                Id = new Guid("418edfff-63b9-4275-9037-8702ca24085a"),
                Name = "Bulgaria",
                Code = "BG",
                IsEu = true,
                IsActive = true,
            };
            countries.Add(country);

            country = new Country()
            {
                Id = new Guid("afc087c9-1609-4834-b407-e64d47dfef63"),
                Name = "Germany",
                Code = "DE",
                IsEu = true,
                IsActive = true,
            };
            countries.Add(country);

            country = new Country()
            {
                Id = new Guid("30ec83ae-2c10-41ea-999f-78f3d2c0fe2a"),
                Name = "United States",
                Code = "US",
                IsEu = false,
                IsActive = true,
            };
            countries.Add(country);

            return countries;
        }
    }
}
