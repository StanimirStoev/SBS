using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBS.Infrastructure.Data.Models
{
    public class Partide
    {
        public Partide()
        {
            PartidesInStores = new HashSet<PartidesInStore>();
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime CreateDatetime { get; set; }

        [Required]
        public Guid ArticleId { get; set; }
        [ForeignKey(nameof(ArticleId))]
        public virtual Article Article { get; set; } = null!;

        [Required]
        public double Qty { get; set; } = 0;

        public virtual ICollection<PartidesInStore> PartidesInStores { get; set; }

    }
}
