using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBS.Core.Models
{
    public class TransferDetailViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public Guid TransferId { get; set; }
        [ForeignKey(nameof(TransferId))]
        public virtual TransferViewModel? Transfer { get; set; }

        [Required]
        public Guid DeliveryDetailId { get; set; }
        [ForeignKey(nameof(DeliveryDetailId))]
        public virtual DeliveryDetailViewModel? DeliveryDetail { get; set; }

        [Required]
        public double Qty { get; set; } = 0;

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
