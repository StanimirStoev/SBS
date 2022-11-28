using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBS.Core.Models
{
    public class SellViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Client")]
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

        [Display(Name = "Sell Price")]
        public double SellTotalPrice
        {
            get
            {
                return Details.Sum(x => x.TotalPrice);
            }
        }

        public virtual List<SellDetailViewModel> Details { get; set; } = new List<SellDetailViewModel>();

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
