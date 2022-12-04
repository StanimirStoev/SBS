using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBS.Infrastructure.Data.Models
{
    /// <summary>
    /// Data for a Delivery
    /// </summary>
    [Comment("Data for a Delivery")]
    public class Delivery
    {
        /// <summary>
        /// Delivery Identifier
        /// </summary>
        [Key]
        [Comment("Delivery Identifier")]
        public Guid Id { get; set; }

        /// <summary>
        /// Contargent (Supplier) Identifier
        /// </summary>
        [Required]
        [Comment("Contargent (Supplier) Identifier")]
        public Guid ContragentId { get; set; }
        /// <summary>
        /// Contargent (Supplier) data
        /// </summary>
        [ForeignKey(nameof(ContragentId))]
        public virtual Contragent Contragent { get; set; } = null!;

        /// <summary>
        /// DateTime of creation
        /// </summary>
        [Required]
        [Comment("DateTime of creation")]
        public DateTime CreateDatetime { get; set; }

        /// <summary>
        /// Store Identifier
        /// </summary>
        [Required]
        [Comment("Store Identifier")]
        public Guid StoreId { get; set; }
        /// <summary>
        /// Store data
        /// </summary>
        [ForeignKey(nameof(StoreId))]
        public virtual Store Store { get; set; } = null!;

        /// <summary>
        /// Details List
        /// </summary>
        public virtual List<DeliveryDetail> Details { get; set; } = new List<DeliveryDetail>();

        /// <summary>
        /// Flag for confermrd sell 
        /// </summary>
        [Required]
        [Comment("Flag for confermrd sell ")]
        public bool IsConfirmed { get; set; } = false;

        /// <summary>
        /// Flag for deleted/in use 
        /// </summary>
        [Required]
        [Comment("Flag for deleted/in use ")]
        public bool IsActive { get; set; } = true;
    }
}
