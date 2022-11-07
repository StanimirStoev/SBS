using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SBS.Infrastructure.Constants.DataConstants.Article;


namespace SBS.Infrastructure.Data.Models
{
    public class Article
    {
        public Article()
        {
            Partides = new HashSet<DeliveryDetail>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(NameMaxLenght)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(ModelMaxLenght)]
        public string Model { get; set; } = null!;

        [StringLength(TitleMaxLenght)]
        public string Title { get; set; } = null!;

        [StringLength(DescriptionMaxLenght)]
        public string? Description { get; set; }

        [StringLength(DeliveryNumberMaxLenght)]
        public string? DeliveryNumber { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public Guid UnitId { get; set; }
        [ForeignKey(nameof(UnitId))]
        public virtual Unit Unit { get; set; }

        public virtual ICollection<DeliveryDetail> Partides { get; set; }
    }
}
