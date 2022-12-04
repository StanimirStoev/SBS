using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SBS.Core.Constants.DataConstants.Article;

namespace SBS.Core.Models
{
    /// <summary>
    /// Data for a Article
    /// </summary>
    public class ArticleViewModel
    {
        /// <summary>
        /// Article Identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of Article
        /// </summary>
        [Required]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = "The field '{0}' must be between {2} and {1} characters lenght.")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Model of Article
        /// </summary>
        [Required]
        [StringLength(ModelMaxLenght, MinimumLength = ModelMinLenght, ErrorMessage = "The field '{0}' must be between {2} and {1} characters lenght.")]
        public string Model { get; set; } = null!;

        /// <summary>
        /// Title of Article
        /// </summary>
        [StringLength(TitleMaxLenght, MinimumLength = TitleMinLenght, ErrorMessage = "The field '{0}' must be between {2} and {1} characters lenght.")]
        public string Title { get; set; } = null!;

        /// <summary>
        /// Description of Article
        /// </summary>
        [StringLength(DescriptionMaxLenght, ErrorMessage = "The field '{0}' can contains max {1} characters.")]
        public string? Description { get; set; }

        /// <summary>
        /// Delivery Number of Article
        /// </summary>
        [Display(Name = "Delivery Number")]
        [StringLength(DeliveryNumberMaxLenght, MinimumLength = DeliveryNumberMinLenght, ErrorMessage = "The field '{0}' must be between {2} and {1} characters lenght.")]
        public string? DeliveryNumber { get; set; }

        /// <summary>
        /// Unit Identifier
        /// </summary>
        [Required]
        public Guid UnitId { get; set; }
        /// <summary>
        /// Unit Data
        /// </summary>
        [ForeignKey(nameof(UnitId))]
        public virtual UnitViewModel? Unit { get; set; }

        /// <summary>
        /// Flag for deleted/in use 
        /// </summary>
        [Required]
        public bool IsActive { get; set; } = true;
    }
}
