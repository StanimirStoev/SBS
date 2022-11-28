using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBS.Core.Models
{
    public class DeliveryViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Supplier")]
        public Guid ContragentId { get; set; }
        [ForeignKey(nameof(ContragentId))]
        public virtual ContragentViewModel? Contragent { get; set; } = null!;

        [Required]
        [Display(Name = "Create Date")]
        public DateTime? CreateDatetime { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Store")]
        public Guid StoreId { get; set; }
        [ForeignKey(nameof(StoreId))]
        public virtual StoreViewModel? Store { get; set; } = null!;

        [Required]
        [Display(Name = "Confirmed")]
        public bool IsConfirmed { get; set; } = false;

        public virtual List<DeliveryDetailViewModel> Details { get; set; } = new List<DeliveryDetailViewModel>();

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
