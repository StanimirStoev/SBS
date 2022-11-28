using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBS.Infrastructure.Data.Models
{
    public class Transfer
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime CreateDatetime { get; set; }

        [Required]
        public Guid FromStoreId { get; set; }
        [ForeignKey(nameof(FromStoreId))]
        public virtual Store FromStore { get; set; } = null!;

        [Required]
        public Guid ToStoreId { get; set; }
        [ForeignKey(nameof(ToStoreId))]
        public virtual Store ToStore { get; set; } = null!;

        public virtual List<TransferDetail> Details { get; set; } = new List<TransferDetail>();

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
