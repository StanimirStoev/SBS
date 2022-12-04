using SBS.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBS.Core.Models
{
    /// <summary>
    /// Deatails for the Delivery
    /// </summary>
    public class DeliveryDetailViewModel
    {
        /// <summary>
        /// Delivery Detail Identifier
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Parent Delivery Identifier
        /// </summary>
        [Required]
        public Guid DeliveryId { get; set; }
        /// <summary>
        /// Parent Delivery data
        /// </summary>
        [ForeignKey(nameof(DeliveryId))]
        public virtual DeliveryViewModel? Delivery { get; set; } = null!;

        /// <summary>
        /// Article Identifier
        /// </summary>
        [Required]
        public Guid ArticleId { get; set; }
        /// <summary>
        /// Article data
        /// </summary>
        [ForeignKey(nameof(ArticleId))]
        public virtual ArticleViewModel? Article { get; set; } = null!;

        /// <summary>
        /// Delivered Quantity
        /// </summary>
        [Required]
        public double Qty { get; set; } = 0;

        /// <summary>
        /// Delivered Price
        /// </summary>
        [Required]
        public double Price { get; set; } = 0;

        /// <summary>
        /// Total price
        /// </summary>
        public double TotalPrice 
        { 
            get
            {
                return Qty * Price;
            }
        }

        /// <summary>
        /// Unit Identifier
        /// </summary>
        [Required]
        public Guid UnitId { get; set; }
        /// <summary>
        /// Unit data
        /// </summary>
        [ForeignKey(nameof(UnitId))]
        public virtual UnitViewModel? Unit { get; set; } = null!;

        /// <summary>
        /// Partides in stores data
        /// </summary>
        public virtual ICollection<PartidesInStore> PartidesInStores { get; set; } = new HashSet<PartidesInStore>();

        /// <summary>
        /// Flag for deleted/in use 
        /// </summary>
        [Required]
        public bool IsActive { get; set; } = true;
    }
}
