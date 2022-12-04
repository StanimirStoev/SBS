using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SBS.Infrastructure.Data.Models;

namespace SBS.Infrastructure.Data.Configuration
{
    /// <summary>
    /// Data for seeding Stores
    /// </summary>
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        /// <summary>
        /// Configure (seed) Stores
        /// </summary>
        /// <param name="builder"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasData(CreateStores());
        }

        private List<Store> CreateStores()
        {
            List<Store> stores = new List<Store>();

            var store = new Store()
            {
                Id = new Guid("c4628027-2999-43b9-9ec4-0fe9df4d3ff2"),
                Name = "Central Store.",
                Description = "Central store for incoming articles",
                AddressId = new Guid("eeb8e279-8df5-4eac-b59c-d04e17639ece"),
                IsActive = true,
            };
            stores.Add(store);

            store = new Store()
            {
                Id = new Guid("7c105c2a-e381-4586-9a3c-32a5aae96cc3"),
                Name = "Export Store",
                Description = "Store for prepared articles to export",
                AddressId = new Guid("171840b5-d316-4274-b4ae-4b7b611a8179"),
                IsActive = true,
            };
            stores.Add(store);

            store = new Store()
            {
                Id = new Guid("e9cbf847-aa4c-4591-b31e-3f7d39ae6389"),
                Name = "Plovdiv Store",
                Description = "Central store for Plovdiv",
                AddressId = new Guid("0cf17f71-ad5c-461a-8a53-3c1c9616eea2"),
                IsActive = true,
            };
            stores.Add(store);

            return stores;
        }
    }
}
