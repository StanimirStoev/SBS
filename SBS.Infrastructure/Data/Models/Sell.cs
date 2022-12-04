using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBS.Infrastructure.Data.Models
{
    /// <summary>
    /// Data for a Sell
    /// </summary>
    [Comment("Data for a Sell")]
    public class Sell
    {
        /// <summary>
        /// Sell Identifier
        /// </summary>
        [Key]
        [Comment("Sell Identifier")]
        public Guid Id { get; set; }

        /// <summary>
        /// Contargent (Client) Identifier
        /// </summary>
        [Required]
        [Comment("Contargent (Client) Identifier")]
        public Guid ContragentId { get; set; }
        /// <summary>
        /// Contargent (Client)
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
        /// Store Data
        /// </summary>
        [ForeignKey(nameof(StoreId))]
        public virtual Store Store { get; set; } = null!;

        /// <summary>
        /// Details List
        /// </summary>
        public virtual List<SellDetail> Details { get; set; } = new List<SellDetail>();

        /// <summary>
        /// Flag for deleted/in use 
        /// </summary>
        [Required]
        [Comment("Flag for deleted/in use ")]
        public bool IsActive { get; set; } = true;
    }
}
