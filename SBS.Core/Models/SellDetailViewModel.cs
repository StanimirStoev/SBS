using SBS.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBS.Core.Models
{
    /// <summary>
    /// Deatails for the Sells
    /// </summary>
    public class SellDetailViewModel
    {
        /// <summary>
        /// Sell Detail Identifier
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Parent Sell Identifier
        /// </summary>
        [Required]
        public Guid SellId { get; set; }
        /// <summary>
        /// Parent Sell 
        /// </summary>
        [ForeignKey(nameof(SellId))]
        public virtual SellViewModel? Sell { get; set; } = null!;

        /// <summary>
        /// Store Sell Identifier
        /// </summary>
        [Required]
        public Guid StoreId { get; set; }

        /// <summary>
        /// DeliveryDetail Identifier
        /// </summary>
        [Required]
        public Guid DeliveryDetailId { get; set; }

        /// <summary>
        /// Partide data
        /// </summary>
        [ForeignKey("StoreId, DeliveryDetailId")]
        public virtual PartidesInStore? PartidesInStore { get; set; } = null!;

        /// <summary>
        /// Quantity to sell
        /// </summary>
        [Required]
        public double Qty { get; set; } = 0;

        /// <summary>
        /// Sell price
        /// </summary>
        [Required]
        public double Price { get; set; } = 0;

        /// <summary>
        /// Total Price
        /// </summary>
        public double TotalPrice
        {
            get
            {
                return Qty * Price;
            }
        }

        /// <summary>
        /// Unit Identifier
        /// </summary>
        [Required]
        public Guid UnitId { get; set; }
        /// <summary>
        /// Unit 
        /// </summary>
        [ForeignKey(nameof(UnitId))]
        public virtual UnitViewModel? Unit { get; set; } = null!;

        /// <summary>
        /// Partides in store
        /// </summary>
        public virtual ICollection<PartidesInStore> PartidesInStores { get; set; } = new HashSet<PartidesInStore>();

        /// <summary>
        /// Flag for deleted/in use 
        /// </summary>
        [Required]
        public bool IsActive { get; set; } = true;
    }
}
