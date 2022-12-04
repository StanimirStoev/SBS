using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBS.Core.Models
{
    /// <summary>
    /// Deatails for the Transfers
    /// </summary>
    public class TransferDetailViewModel
    {
        /// <summary>
        /// Tarnsfer Detail Identifier
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Parent Tarnsfer Identifier
        /// </summary>
        public Guid TransferId { get; set; }
        /// <summary>
        /// Parent Tarnsfer
        /// </summary>
        [ForeignKey(nameof(TransferId))]
        public virtual TransferViewModel? Transfer { get; set; }

        /// <summary>
        /// Delivery Detail Identifier
        /// </summary>
        [Required]
        public Guid DeliveryDetailId { get; set; }
        /// <summary>
        /// Delivery Detail
        /// </summary>
        [ForeignKey(nameof(DeliveryDetailId))]
        public virtual DeliveryDetailViewModel? DeliveryDetail { get; set; }

        /// <summary>
        /// Transfered Quantity
        /// </summary>
        [Required]
        public double Qty { get; set; } = 0;

        /// <summary>
        /// Flag for deleted/in use 
        /// </summary>
        [Required]
        public bool IsActive { get; set; } = true;
    }
}
