using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SBS.Infrastructure.Data.Models;

namespace SBS.Infrastructure.Data.Configuration
{
    /// <summary>
    /// Data for seeding Cities
    /// </summary>
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        /// <summary>
        /// Configure (seed) Cities
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData(CreateCities());
        }

        private List<City> CreateCities()
        {
            List<City> cities = new List<City>();

            var city = new City()
            {
                Id = new Guid("c0eef3b2-d651-41dc-9525-e1e77d82df54"),
                Name = "Sofia",
                CountryId = new Guid("418edfff-63b9-4275-9037-8702ca24085a"),
                IsActive = true,
            };
            cities.Add(city);

            city = new City()
            {
                Id = new Guid("5d1c80b6-b785-4676-8b82-ac7fd4015b5e"),
                Name = "Plovdiv",
                CountryId = new Guid("418edfff-63b9-4275-9037-8702ca24085a"),
                IsActive = true,
            };
            cities.Add(city);

            city = new City()
            {
                Id = new Guid("6402b8cf-af94-406a-878e-d89db204e082"),
                Name = "New York",
                CountryId = new Guid("30ec83ae-2c10-41ea-999f-78f3d2c0fe2a"),
                IsActive = true,
            };
            cities.Add(city);

            return cities;
        }
    }
}
