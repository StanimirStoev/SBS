using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBS.Core.Models
{
    /// <summary>
    /// Data for a Delivery
    /// </summary>
    public class DeliveryViewModel
    {
        /// <summary>
        /// Delivery Identifier
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Contargent (Supplier) Identifier
        /// </summary>
        [Required]
        [Display(Name = "Supplier")]
        public Guid ContragentId { get; set; }
        /// <summary>
        /// Contargent (Supplier) data
        /// </summary>
        [ForeignKey(nameof(ContragentId))]
        public virtual ContragentViewModel? Contragent { get; set; } = null!;

        /// <summary>
        /// DateTime of creation
        /// </summary>
        [Required]
        [Display(Name = "Create Date")]
        public DateTime? CreateDatetime { get; set; } = DateTime.Now;

        /// <summary>
        /// Store Identifier
        /// </summary>
        [Required]
        [Display(Name = "Store")]
        public Guid StoreId { get; set; }
        /// <summary>
        /// Store data
        /// </summary>
        [ForeignKey(nameof(StoreId))]
        public virtual StoreViewModel? Store { get; set; } = null!;

        /// <summary>
        /// Flag for confermrd sell 
        /// </summary>
        [Required]
        [Display(Name = "Confirmed")]
        public bool IsConfirmed { get; set; } = false;

        /// <summary>
        /// Details List
        /// </summary>
        public virtual List<DeliveryDetailViewModel> Details { get; set; } = new List<DeliveryDetailViewModel>();

        /// <summary>
        /// Flag for deleted/in use 
        /// </summary>
        [Required]
        public bool IsActive { get; set; } = true;
    }
}
