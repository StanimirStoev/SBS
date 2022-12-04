using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SBS.Infrastructure.Data.Models;

namespace SBS.Infrastructure.Data.Configuration
{
    /// <summary>
    /// Data for seeding Addresses
    /// </summary>
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        /// <summary>
        /// Configure (seed) Addresses
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasData(CreateAddresses());
        }

        private List<Address> CreateAddresses()
        {
            List<Address> addresses = new List<Address>();

            var address = new Address()
            {
                Id = new Guid("bb884490-1ae1-4caf-a4ac-55bf6394bc9d"),
                CountryId = new Guid("30ec83ae-2c10-41ea-999f-78f3d2c0fe2a"),
                CityId = new Guid("6402b8cf-af94-406a-878e-d89db204e082"),
                AddressLine1 = "526 New Ave.",
                AddressLine2 = "Brooklyn, NY 11237",
                ContragentId = new Guid("0625109a-585a-4c4e-be30-5a18b1e311f8"),
                IsActive = true,
            };
            addresses.Add(address);

            address = new Address()
            {
                Id = new Guid("eeb8e279-8df5-4eac-b59c-d04e17639ece"),
                CountryId = new Guid("418edfff-63b9-4275-9037-8702ca24085a"),
                CityId = new Guid("c0eef3b2-d651-41dc-9525-e1e77d82df54"),
                AddressLine1 = "14 Tzar Osvoboditel Blvd.",
                AddressLine2 = "fl. 1",
                IsActive = true,
            };
            addresses.Add(address);

            address = new Address()
            {
                Id = new Guid("283c85c8-0113-48f3-b5c8-3187f9299bf8"),
                CountryId = new Guid("418edfff-63b9-4275-9037-8702ca24085a"),
                CityId = new Guid("c0eef3b2-d651-41dc-9525-e1e77d82df54"),
                AddressLine1 = "1 Murgash Str.",
                AddressLine2 = "fl. 2; pl. 3",
                ContragentId = new Guid("e9e67ae0-84c7-4279-96fc-bf12baaea7e9"),
                IsActive = true,
            };
            addresses.Add(address);

            address = new Address()
            {
                Id = new Guid("171840b5-d316-4274-b4ae-4b7b611a8179"),
                CountryId = new Guid("418edfff-63b9-4275-9037-8702ca24085a"),
                CityId = new Guid("c0eef3b2-d651-41dc-9525-e1e77d82df54"),
                AddressLine1 = "6 Gurko Str.",
                AddressLine2 = "fl. 1",
                IsActive = true,
            };
            addresses.Add(address);

            address = new Address()
            {
                Id = new Guid("68042d85-077e-4383-9c0d-0ffbc3c4fd96"),
                CountryId = new Guid("418edfff-63b9-4275-9037-8702ca24085a"),
                CityId = new Guid("5d1c80b6-b785-4676-8b82-ac7fd4015b5e"),
                AddressLine1 = "30 Peshtersko shose Blvd.",
                AddressLine2 = "fl. 3; pl. 7",
                ContragentId = new Guid("c85f94df-a849-42b7-a08b-e7ef758dfb43"),
                IsActive = true,
            };
            addresses.Add(address);

            address = new Address()
            {
                Id = new Guid("0cf17f71-ad5c-461a-8a53-3c1c9616eea2"),
                CountryId = new Guid("418edfff-63b9-4275-9037-8702ca24085a"),
                CityId = new Guid("5d1c80b6-b785-4676-8b82-ac7fd4015b5e"),
                AddressLine1 = "12 Blagovest Str.",
                AddressLine2 = "fl. 1",
                IsActive = true,
            };
            addresses.Add(address);


            return addresses;
        }
    }
}
