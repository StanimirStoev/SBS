using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SBS.Infrastructure.Data.Configuration;
using SBS.Infrastructure.Data.Models;
using SBS.Infrastructure.Data.Models.Account;

namespace SBS.Infrastructure.Data
{
    /// <summary>
    /// Database context for application
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Initialise 
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
        }
        /// <summary>
        /// Prepare Database context
        /// </summary>
        /// <param name="builder"></param>
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

            builder.Entity<Transfer>()
                .HasOne<Store>(t => t.FromStore)
                .WithMany(s => s.TransferStoresFrom)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Transfer>()
                .HasOne<Store>(t => t.ToStore)
                .WithMany(s => s.TransferStoresTo)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<SellDetail>()
                .HasOne(s => s.Unit)
                .WithMany(u => u.SellDetails)
                .OnDelete(DeleteBehavior.NoAction);

            builder.ApplyConfiguration(new UserConfiguration());

        }

        /// <summary>
        /// Present Address entity data.
        /// </summary>
        public DbSet<Address> Addresses { get; set; } = null!;
        /// <summary>
        /// Present Articles entity data.
        /// </summary>
        public DbSet<Article> Articles { get; set; } = null!;
        /// <summary>
        /// Present Cities entity data.
        /// </summary>
        public DbSet<City> Cities { get; set; } = null!;
        /// <summary>
        /// Present Contragents entity data.
        /// </summary>
        public DbSet<Contragent> Contragents { get; set; } = null!;
        /// <summary>
        /// Present Countries entity data.
        /// </summary>
        public DbSet<Country> Countries { get; set; } = null!;
        /// <summary>
        /// Present Stores entity data.
        /// </summary>
        public DbSet<Store> Stores { get; set; } = null!;
        /// <summary>
        /// Present Units entity data.
        /// </summary>
        public DbSet<Unit> Units { get; set; } = null!;
        /// <summary>
        /// Present Deliveries entity data.
        /// </summary>
        public DbSet<Delivery> Deliveries { get; set; } = null!;
        /// <summary>
        /// Present DeliveryDetails entity data.
        /// </summary>
        public DbSet<DeliveryDetail> DeliveryDetails { get; set; } = null!;
        /// <summary>
        /// Present PartidesInStores entity data.
        /// </summary>
        public DbSet<PartidesInStore> PartidesInStores { get; set; } = null!;
        /// <summary>
        /// Present Transfers entity data.
        /// </summary>
        public DbSet<Transfer> Transfers { get; set; } = null!;
        /// <summary>
        /// Present TransferDetails entity data.
        /// </summary>
        public DbSet<TransferDetail> TransferDetails { get; set; } = null!;
        /// <summary>
        /// Present Sells entity data.
        /// </summary>
        public DbSet<Sell> Sells { get; set; } = null!;
        /// <summary>
        /// Present SellDetails entity data.
        /// </summary>
        public DbSet<SellDetail> SellDetails { get; set; } = null!;
    }
}
