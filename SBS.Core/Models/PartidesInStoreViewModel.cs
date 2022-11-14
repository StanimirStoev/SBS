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
