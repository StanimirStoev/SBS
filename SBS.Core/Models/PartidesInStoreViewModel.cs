using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBS.Core.Models
{
    public class PartidesInStoreViewModel
    {
        [Required]
        public Guid StoreId { get; set; }
        [ForeignKey(nameof(StoreId))]
        public virtual StoreViewModel Store { get; set; } = null!;

        [Required]
        public Guid DeliveryDetailId { get; set; }
        [ForeignKey(nameof(DeliveryDetailId))]
        public virtual DeliveryDetailViewModel DeliveryDetail { get; set; } = null!;

        [Required]
        public double Qty { get; set; } = 0;
    }
}
