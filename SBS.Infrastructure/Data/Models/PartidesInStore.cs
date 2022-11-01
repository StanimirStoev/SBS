using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBS.Infrastructure.Data.Models
{
    public class PartidesInStore
    {
        [Required]
        public Guid StoreId { get; set; }
        [ForeignKey(nameof(StoreId))]
        public virtual Store Store { get; set; } = null!;

        [Required]
        public Guid PartideId { get; set; }
        [ForeignKey(nameof(PartideId))]
        public virtual Partide Partide { get; set; } = null!;

        [Required]
        public double Qty { get; set; } = 0;
    }
}
