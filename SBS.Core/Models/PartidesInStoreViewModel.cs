using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBS.Core.Models
{
    /// <summary>
    /// Partides quantity in the stores
    /// </summary>
    public class PartidesInStoreViewModel
    {
        /// <summary>
        /// Store Identifier
        /// </summary>
        [Required]
        public Guid StoreId { get; set; }
        /// <summary>
        /// Store Data
        /// </summary>
        [ForeignKey(nameof(StoreId))]
        public virtual StoreViewModel Store { get; set; } = null!;

        /// <summary>
        /// DeliveryDetail (Partide) Identifier
        /// </summary>
        [Required]
        public Guid DeliveryDetailId { get; set; }
        /// <summary>
        /// DeliveryDetail (Partide) Data
        /// </summary>
        [ForeignKey(nameof(DeliveryDetailId))]
        public virtual DeliveryDetailViewModel DeliveryDetail { get; set; } = null!;

        /// <summary>
        /// Flag for deleted/in use 
        /// </summary>
        [Required]
        public double Qty { get; set; } = 0;
    }
}
