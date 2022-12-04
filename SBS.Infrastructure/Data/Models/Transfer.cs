using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBS.Infrastructure.Data.Models
{
    /// <summary>
    /// Transfer Data
    /// </summary>
    [Comment("Transfer Data")]
    public class Transfer
    {
        /// <summary>
        /// Tarnsfer Identifier
        /// </summary>
        [Key]
        [Comment("Tarnsfer Identifier")]
        public Guid Id { get; set; }

        /// <summary>
        /// Tarnsfer Date of creation
        /// </summary>
        [Required]
        [Comment("Tarnsfer Date of creation")]
        public DateTime CreateDatetime { get; set; }

        /// <summary>
        /// Tarnsfer source store Identifier
        /// </summary>
        [Required]
        [Comment("Tarnsfer source store Identifier")]
        public Guid FromStoreId { get; set; }
        /// <summary>
        /// Tarnsfer source store
        /// </summary>
        [ForeignKey(nameof(FromStoreId))]
        public virtual Store FromStore { get; set; } = null!;

        /// <summary>
        /// Tarnsfer destination store Identifier
        /// </summary>
        [Required]
        [Comment("Tarnsfer destination store Identifier")]
        public Guid ToStoreId { get; set; }
        /// <summary>
        /// Tarnsfer destination store 
        /// </summary>
        [ForeignKey(nameof(ToStoreId))]
        public virtual Store ToStore { get; set; } = null!;

        /// <summary>
        /// List of transfer details 
        /// </summary>
        public virtual List<TransferDetail> Details { get; set; } = new List<TransferDetail>();

        /// <summary>
        /// Flag for deleted/in use 
        /// </summary>
        [Required]
        [Comment("Flag for deleted/in use")]
        public bool IsActive { get; set; } = true;
    }
}
