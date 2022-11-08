using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SBS.Infrastructure.Data.Models;
using SBS.Infrastructure.Data.Models.Account;

namespace SBS.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Address>()
                .HasOne(a => a.Country)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => a.CountryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<PartidesInStore>()
                .HasKey(nameof(PartidesInStore.StoreId), nameof(PartidesInStore.DeliveryDetailId));
            builder.Entity<PartidesInStore>()
                .HasOne(ps => ps.Store)
                .WithMany(s => s.PartidesInStores)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<PartidesInStore>()
                .HasOne(ps => ps.DeliveryDetail)
                .WithMany(d => d.PartidesInStores)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<DeliveryDetail>()
                .HasOne(d => d.Unit)
                .WithMany(u => u.DeliveryDetails)
                .OnDelete(DeleteBehavior.NoAction);

        }
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<Article> Articles { get; set; } = null!;
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<Contragent> Contragents { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Store> Stores { get; set; } = null!;
        public DbSet<Unit> Units { get; set; } = null!;
        public DbSet<Delivery> Deliveries { get; set; } = null!;
        public DbSet<DeliveryDetail> DeliveryDetails { get; set; } = null!;
        public DbSet<PartidesInStore> PartidesInStores { get; set; } = null!;
    }
}
