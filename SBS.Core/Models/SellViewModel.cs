using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBS.Core.Models
{
    /// <summary>
    /// Data for a Sell
    /// </summary>
    public class SellViewModel
    {
        /// <summary>
        /// Sell Identifier
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Contargent (Client) Identifier
        /// </summary>
        [Required]
        [Display(Name = "Client")]
        public Guid ContragentId { get; set; }
        /// <summary>
        /// Contargent (Client)
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
        /// Store Data
        /// </summary>
        [ForeignKey(nameof(StoreId))]
        public virtual StoreViewModel? Store { get; set; } = null!;

        /// <summary>
        /// Total price
        /// </summary>
        [Display(Name = "Sell Price")]
        public double SellTotalPrice
        {
            get
            {
                return Details.Sum(x => x.TotalPrice);
            }
        }

        /// <summary>
        /// Details List
        /// </summary>
        public virtual List<SellDetailViewModel> Details { get; set; } = new List<SellDetailViewModel>();

        /// <summary>
        /// Flag for deleted/in use 
        /// </summary>
        [Required]
        public bool IsActive { get; set; } = true;
    }
}
