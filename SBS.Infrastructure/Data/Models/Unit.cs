using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SBS.Infrastructure.Constants.DataConstants.Unit;

namespace SBS.Infrastructure.Data.Models
{
    /// <summary>
    /// Measuring units
    /// </summary>
    [Comment("Measuring units")]
    public class Unit
    {
        /// <summary>
        /// Unit Identifier
        /// </summary>
        [Key]
        [Comment("Unit Identifier")]
        public Guid Id { get; set; }

        /// <summary>
        /// Unit Short Name
        /// </summary>
        [Required]
        [StringLength(NameMaxLenght)]
        [Comment("Unit Short Name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Unit Description
        /// </summary>
        [StringLength(DescriptionMaxLenght)]
        [Comment("Unit Description")]
        public string? Description { get; set; }

        /// <summary>
        /// List of delivery details
        /// </summary>
        public virtual List<DeliveryDetail> DeliveryDetails { get; set; } = new List<DeliveryDetail>();

        /// <summary>
        /// List of sell details
        /// </summary>
        public virtual List<SellDetail> SellDetails { get; set; } = new List<SellDetail>();

        /// <summary>
        /// Flag for deleted/in use Unit
        /// </summary>
        [Required]
        [Comment("Flag for deleted/in use Units")]
        public bool IsActive { get; set; } = true;
    }
}
