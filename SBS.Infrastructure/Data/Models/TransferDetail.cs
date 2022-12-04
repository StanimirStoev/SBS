using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBS.Infrastructure.Data.Models
{
    /// <summary>
    /// Deatails for the Transfers
    /// </summary>
    [Comment("Deatails for the Transfers")]
    public class TransferDetail
    {
        /// <summary>
        /// Tarnsfer Detail Identifier
        /// </summary>
        [Key]
        [Comment("Tarnsfer Detail Identifier")]
        public Guid Id { get; set; }

        /// <summary>
        /// Parent Tarnsfer Identifier
        /// </summary>
        [Required]
        [Comment("Parent Tarnsfer Identifier")]
        public Guid TransferId { get; set; }
        /// <summary>
        /// Parent Tarnsfer
        /// </summary>
        [ForeignKey(nameof(TransferId))]
        public virtual Transfer Transfer { get; set; } = null!;

        /// <summary>
        /// Delivery Detail Identifier
        /// </summary>
        [Required]
        [Comment("Delivery Detail Identifier")]
        public Guid DeliveryDetailId { get; set; }
        /// <summary>
        /// Delivery Detail
        /// </summary>
        [ForeignKey(nameof(DeliveryDetailId))]
        public virtual DeliveryDetail DeliveryDetail { get; set; } = null!;

        /// <summary>
        /// Transfered Quantity
        /// </summary>
        [Required]
        [Comment("Transfered Quantity")]
        public double Qty { get; set; } = 0;

        /// <summary>
        /// Flag for deleted/in use 
        /// </summary>
        [Required]
        [Comment("Flag for deleted/in use ")]
        public bool IsActive { get; set; } = true;
    }
}
