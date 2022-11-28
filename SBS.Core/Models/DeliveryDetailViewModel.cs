using SBS.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBS.Core.Models
{
    public class DeliveryDetailViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid DeliveryId { get; set; }
        [ForeignKey(nameof(DeliveryId))]
        public virtual DeliveryViewModel? Delivery { get; set; } = null!;

        [Required]
        public Guid ArticleId { get; set; }
        [ForeignKey(nameof(ArticleId))]
        public virtual ArticleViewModel? Article { get; set; } = null!;

        [Required]
        public double Qty { get; set; } = 0;

        [Required]
        public double Price { get; set; } = 0;

        public double TotalPrice 
        { 
            get
            {
                return Qty * Price;
            }
        }

        [Required]
        public Guid UnitId { get; set; }
        [ForeignKey(nameof(UnitId))]
        public virtual UnitViewModel? Unit { get; set; } = null!;

        public virtual ICollection<PartidesInStore> PartidesInStores { get; set; } = new HashSet<PartidesInStore>();

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
