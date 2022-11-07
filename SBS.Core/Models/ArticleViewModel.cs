using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SBS.Core.Constants.DataConstants.Article;

namespace SBS.Core.Models
{
    public class ArticleViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = "The field '{0}' must be between {2} and {1} characters lenght.")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(ModelMaxLenght, MinimumLength = ModelMinLenght, ErrorMessage = "The field '{0}' must be between {2} and {1} characters lenght.")]
        public string Model { get; set; } = null!;

        [StringLength(TitleMaxLenght, MinimumLength = TitleMinLenght, ErrorMessage = "The field '{0}' must be between {2} and {1} characters lenght.")]
        public string Title { get; set; } = null!;

        [StringLength(DescriptionMaxLenght, ErrorMessage = "The field '{0}' can contains max {1} characters.")]
        public string? Description { get; set; }

        [Display(Name = "Delivery Number")]
        [StringLength(DeliveryNumberMaxLenght, MinimumLength = DeliveryNumberMinLenght, ErrorMessage = "The field '{0}' must be between {2} and {1} characters lenght.")]
        public string? DeliveryNumber { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public Guid UnitId { get; set; }
        [ForeignKey(nameof(UnitId))]
        public virtual UnitViewModel? Unit { get; set; }
    }
}
