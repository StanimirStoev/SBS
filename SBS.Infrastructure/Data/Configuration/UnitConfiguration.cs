using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SBS.Infrastructure.Data.Models;

namespace SBS.Infrastructure.Data.Configuration
{
    /// <summary>
    /// Data for seeding Units
    /// </summary>
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        /// <summary>
        /// Configure (seed) Units
        /// </summary>
        /// <param name="builder"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.HasData(CreateUnits()); 
        }

        private List<Unit> CreateUnits()
        {
            List<Unit> units = new List<Unit>();

            var unit = new Unit()
            {
                Id = new Guid("a96f16ba-b522-4dd9-9ca6-7425fd7044f6"),
                Name = "pcs",
                Description = "Pieces",
                IsActive = true,
            };
            units.Add(unit);

            unit = new Unit()
            {
                Id = new Guid("20b0aaca-9283-4486-be89-ed67e515c2e2"),
                Name = "m",
                Description = "Meters",
                IsActive = true,
            };
            units.Add(unit);

            unit = new Unit()
            {
                Id = new Guid("b830df7a-9bba-44db-bf48-39b2f76881bd"),
                Name = "kg",
                Description = "Kilograms",
                IsActive = true,
            };
            units.Add(unit);

            return units;
        }
    }
}
