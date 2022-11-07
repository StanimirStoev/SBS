using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBS.Infrastructure.Data.Models
{
    public class DeliveryDetail
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid DeliveryId { get; set; }
        [ForeignKey(nameof(DeliveryId))]
        public virtual Delivery Delivery { get; set; } = null!;

        [Required]
        public Guid ArticleId { get; set; }
        [ForeignKey(nameof(ArticleId))]
        public virtual Article Article { get; set; } = null!;

        [Required]
        public double Qty { get; set; } = 0;

        [Required]
        public double Price { get; set; } = 0;

        public virtual ICollection<PartidesInStore> PartidesInStores { get; set; } = new HashSet<PartidesInStore>();
    }
}
