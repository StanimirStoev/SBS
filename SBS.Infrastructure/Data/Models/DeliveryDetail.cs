using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBS.Infrastructure.Data.Models
{
    /// <summary>
    /// Deatails for the Delivery
    /// </summary>
    [Comment("Deatails for the Delivery")]
    public class DeliveryDetail
    {

        /// <summary>
        /// Delivery Detail Identifier
        /// </summary>
        [Key]
        [Comment("Delivery Detail Identifier")]
        public Guid Id { get; set; }

        /// <summary>
        /// Parent Delivery Identifier
        /// </summary>
        [Required]
        [Comment("Parent Delivery Identifier")]
        public Guid DeliveryId { get; set; }
        /// <summary>
        /// Parent Delivery data
        /// </summary>
        [ForeignKey(nameof(DeliveryId))]
        public virtual Delivery Delivery { get; set; } = null!;

        /// <summary>
        /// Article Identifier
        /// </summary>
        [Required]
        [Comment("Article Identifier")]
        public Guid ArticleId { get; set; }
        /// <summary>
        /// Article data
        /// </summary>
        [ForeignKey(nameof(ArticleId))]
        public virtual Article Article { get; set; } = null!;

        /// <summary>
        /// Unit Identifier
        /// </summary>
        [Required]
        [Comment("Unit Identifier")]
        public Guid UnitId { get; set; }
        /// <summary>
        /// Unit data
        /// </summary>
        [ForeignKey(nameof(UnitId))]
        public virtual Unit Unit { get; set; } = null!;

        /// <summary>
        /// Delivered Quantity
        /// </summary>
        [Required]
        [Comment("Delivered Quantity")]
        public double Qty { get; set; } = 0;

        /// <summary>
        /// Delivered Price
        /// </summary>
        [Required]
        [Comment("Delivered Price")]
        public double Price { get; set; } = 0;

        /// <summary>
        /// Partides in stores data
        /// </summary>
        public virtual ICollection<PartidesInStore> PartidesInStores { get; set; } = new HashSet<PartidesInStore>();

        /// <summary>
        /// Flag for deleted/in use 
        /// </summary>
        [Required]
        [Comment("Flag for deleted/in use ")]
        public bool IsActive { get; set; } = true;
    }
}
