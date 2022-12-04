using System.ComponentModel.DataAnnotations;
using static SBS.Core.Constants.DataConstants.Contragent;

namespace SBS.Core.Models
{
    /// <summary>
    /// Data for a Contragent (Client or Supplier)
    /// </summary>
    public class ContragentViewModel
    {
        /// <summary>
        /// Init new Contragent
        /// </summary>
        public ContragentViewModel()
        {
            Addresses = new List<AddressViewModel>();
        }

        /// <summary>
        /// Contragent Identifier
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// First Name of Contragent
        /// </summary>
        [Required]
        [Display(Name = "Fist Name")]
        [StringLength(FirstNameMaxLenght, MinimumLength = FirstNameMinLenght, ErrorMessage = "The field '{0}' must be between {2} and {1} characters lenght.")]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Last Name of Contragent
        /// </summary>
        [Display(Name ="Last Name")]
        [StringLength(LastNameMaxLenght, MinimumLength = LastNameMinLenght, ErrorMessage = "The field '{0}' must be between {2} and {1} characters lenght.")]
        public string LastName { get; set; } = null!;

        /// <summary>
        /// List os addresses for the contragent
        /// </summary>
        public virtual List<AddressViewModel> Addresses { get; set; }

        /// <summary>
        /// Vat Number of Contragent (EGN when private person)
        /// </summary>
        [Display(Name ="Vat Number")]
        [StringLength(VatNumberMaxLenght, MinimumLength = VatNumberMinLenght, ErrorMessage = "The field '{0}' must be between {2} and {1} characters lenght.")]
        public string VatNumber { get; set; } = null!;

        /// <summary>
        /// Flag is the contragent can be client
        /// </summary>
        [Required]
        [Display(Name = "Client")]
        public bool IsClient { get; set; } = true;

        /// <summary>
        /// Flag is the contragent can be supplier
        /// </summary>
        [Required]
        [Display(Name = "Supplier")]
        public bool IsSupplier { get; set; } = false;

        /// <summary>
        /// Flag for deleted/in use 
        /// </summary>
        [Required]
        public bool IsActive { get; set; } = true;
    }
}
