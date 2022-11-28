using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBS.Infrastructure.Data.Models
{
    public class TransferDetail
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid TransferId { get; set; }
        [ForeignKey(nameof(TransferId))]
        public virtual Transfer Transfer { get; set; } = null!;

        [Required]
        public Guid DeliveryDetailId { get; set; }
        [ForeignKey(nameof(DeliveryDetailId))]
        public virtual DeliveryDetail DeliveryDetail { get; set; } = null!;

        [Required]
        public double Qty { get; set; } = 0;

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
