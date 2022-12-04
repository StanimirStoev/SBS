using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SBS.Infrastructure.Constants.DataConstants.Article;


namespace SBS.Infrastructure.Data.Models
{
    /// <summary>
    /// Data for a Article
    /// </summary>
    [Comment("Data for a Article")]
    public class Article
    {
        /// <summary>
        /// init new Article
        /// </summary>
        public Article()
        {
            Partides = new HashSet<DeliveryDetail>();
        }

        /// <summary>
        /// Article Identifier
        /// </summary>
        [Key]
        [Comment("Article Identifier")]
        public Guid Id { get; set; }

        /// <summary>
        /// Name of Article
        /// </summary>
        [Required]
        [StringLength(NameMaxLenght)]
        [Comment("Name of Article")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Model of Article
        /// </summary>
        [Required]
        [StringLength(ModelMaxLenght)]
        [Comment("Model of Article")]
        public string Model { get; set; } = null!;

        /// <summary>
        /// Title of Article
        /// </summary>
        [StringLength(TitleMaxLenght)]
        [Comment("Title of Article")]
        public string Title { get; set; } = null!;

        /// <summary>
        /// Description of Article
        /// </summary>
        [StringLength(DescriptionMaxLenght)]
        [Comment("Description of Article")]
        public string? Description { get; set; }

        /// <summary>
        /// Delivery Number of Article
        /// </summary>
        [StringLength(DeliveryNumberMaxLenght)]
        [Comment("Delivery Number of Article")]
        public string? DeliveryNumber { get; set; }

        /// <summary>
        /// Unit Identifier
        /// </summary>
        [Required]
        [Comment("Unit Identifier")]
        public Guid UnitId { get; set; }
        /// <summary>
        /// Unit Data
        /// </summary>
        [ForeignKey(nameof(UnitId))]
        public virtual Unit Unit { get; set; } = null!;

        /// <summary>
        /// List Partides (Delivery Details)
        /// </summary>
        public virtual ICollection<DeliveryDetail> Partides { get; set; }

        /// <summary>
        /// Flag for deleted/in use 
        /// </summary>
        [Required]
        [Comment("Flag for deleted/in use ")]
        public bool IsActive { get; set; } = true;
    }
}
