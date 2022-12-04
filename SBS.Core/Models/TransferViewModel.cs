using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBS.Core.Models
{
    /// <summary>
    /// Data for the Transfers
    /// </summary>
    public class TransferViewModel
    {
        /// <summary>
        /// Tarnsfer Identifier
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Tarnsfer Date of creation
        /// </summary>
        [Required]
        [Display(Name = "Create Date")]
        public DateTime CreateDatetime { get; set; } = DateTime.Now;

        /// <summary>
        /// Tarnsfer source store Identifier
        /// </summary>
        [Required]
        [Display(Name = "From Store")]
        public Guid FromStoreId { get; set; }
        /// <summary>
        /// Tarnsfer source store
        /// </summary>
        [ForeignKey(nameof(FromStoreId))]
        public virtual StoreViewModel? FromStore { get; set; }

        /// <summary>
        /// Tarnsfer destination store Identifier
        /// </summary>
        [Required]
        [Display(Name = "To Store")]
        public Guid ToStoreId { get; set; }
        /// <summary>
        /// Tarnsfer destination store 
        /// </summary>
        [ForeignKey(nameof(ToStoreId))]
        public virtual StoreViewModel? ToStore { get; set; }

        /// <summary>
        /// List of transfer details 
        /// </summary>
        public virtual List<TransferDetailViewModel> Details { get; set; } = new List<TransferDetailViewModel>();

        /// <summary>
        /// Flag for deleted/in use 
        /// </summary>
        [Required]
        public bool IsActive { get; set; } = true;
    }
}
