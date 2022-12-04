using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBS.Infrastructure.Data.Models
{
    /// <summary>
    /// Partides quantity in the stores
    /// </summary>
    [Comment("Partides quantity in the stores")]
    public class PartidesInStore
    {
        /// <summary>
        /// Store Identifier
        /// </summary>
        [Required]
        [Comment("Store Identifier")]
        public Guid StoreId { get; set; }
        /// <summary>
        /// Store Data
        /// </summary>
        [ForeignKey(nameof(StoreId))]
        public virtual Store Store { get; set; } = null!;

        /// <summary>
        /// DeliveryDetail (Partide) Identifier
        /// </summary>
        [Required]
        [Comment("DeliveryDetail (Partide) Identifier")]
        public Guid DeliveryDetailId { get; set; }
        /// <summary>
        /// DeliveryDetail (Partide) Data
        /// </summary>
        [ForeignKey(nameof(DeliveryDetailId))]
        public virtual DeliveryDetail DeliveryDetail { get; set; } = null!;

        /// <summary>
        /// Flag for deleted/in use 
        /// </summary>
        [Required]
        [Comment("Flag for deleted/in use ")]
        public double Qty { get; set; } = 0;
    }
}
