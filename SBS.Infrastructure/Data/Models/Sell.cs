using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBS.Infrastructure.Data.Models
{
    public class Sell
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ContragentId { get; set; }
        [ForeignKey(nameof(ContragentId))]
        public virtual Contragent Contragent { get; set; } = null!;

        [Required]
        public DateTime CreateDatetime { get; set; }

        [Required]
        public Guid StoreId { get; set; }
        [ForeignKey(nameof(StoreId))]
        public virtual Store Store { get; set; } = null!;

        public virtual List<SellDetail> Details { get; set; } = new List<SellDetail>();

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
