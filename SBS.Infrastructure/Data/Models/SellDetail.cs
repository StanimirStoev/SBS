using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBS.Infrastructure.Data.Models
{
    /// <summary>
    /// Deatails for the Sells
    /// </summary>
    [Comment("Deatails for the Sells")]
    public class SellDetail
    {
        /// <summary>
        /// Sell Detail Identifier
        /// </summary>
        [Key]
        [Comment("Sell Detail Identifier")]
        public Guid Id { get; set; }

        /// <summary>
        /// Parent Sell Identifier
        /// </summary>
        [Required]
        [Comment("Parent Sell Identifier")]
        public Guid SellId { get; set; }
        /// <summary>
        /// Parent Sell 
        /// </summary>
        [ForeignKey(nameof(SellId))]
        public virtual Sell Sell { get; set; } = null!;

        /// <summary>
        /// Store Sell Identifier
        /// </summary>
        [Required]
        [Comment("Store Sell Identifier")]
        public Guid StoreId { get; set; }

        /// <summary>
        /// DeliveryDetail Identifier
        /// </summary>
        [Required]
        [Comment("DeliveryDetail Identifier")]
        public Guid DeliveryDetailId { get; set; }

        /// <summary>
        /// Partide data
        /// </summary>
        [ForeignKey("StoreId, DeliveryDetailId")]
        public virtual PartidesInStore PartidesInStore { get; set; } = null!;

        /// <summary>
        /// Unit Identifier
        /// </summary>
        [Required]
        [Comment("Unit Identifier")]
        public Guid UnitId { get; set; }
        /// <summary>
        /// Unit 
        /// </summary>
        [ForeignKey(nameof(UnitId))]
        public virtual Unit Unit { get; set; } = null!;

        /// <summary>
        /// Quantity to sell
        /// </summary>
        [Required]
        [Comment("Quantity to sell")]
        public double Qty { get; set; } = 0;

        /// <summary>
        /// Sell price
        /// </summary>
        [Required]
        [Comment("Sell price")]
        public double Price { get; set; } = 0;

        /// <summary>
        /// Partides in store
        /// </summary>
        public virtual ICollection<PartidesInStore> PartidesInStores { get; set; } = new HashSet<PartidesInStore>();

        /// <summary>
        /// Flag for deleted/in use 
        /// </summary>
        [Required]
        [Comment("Flag for deleted/in use ")]
        public bool IsActive { get; set; } = true;
    }
}
