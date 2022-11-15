using SBS.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
