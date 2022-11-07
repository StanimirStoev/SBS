using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Core.Models
{
    public class DeliveryViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ContragentId { get; set; }
        [ForeignKey(nameof(ContragentId))]
        public virtual ContragentViewModel Contragent { get; set; } = null!;

        [Required]
        public DateTime? CreateDatetime { get; set; }

        [Required]
        public Guid StoreId { get; set; }
        [ForeignKey(nameof(StoreId))]
        public virtual StoreViewModel Store { get; set; } = null!;

        public virtual List<DeliveryDetailViewModel> Details { get; set; } = new List<DeliveryDetailViewModel>();

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
