using System.ComponentModel.DataAnnotations;
using static SBS.Core.Constants.DataConstants.Contragent;

namespace SBS.Core.Models
{
    public class ContragentViewModel
    {
        public ContragentViewModel()
        {
            Addresses = new List<AddressViewModel>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Fist Name")]
        [StringLength(FirstNameMaxLenght, MinimumLength = FirstNameMinLenght, ErrorMessage = "The field '{0}' must be between {2} and {1} characters lenght.")]
        public string FirstName { get; set; } = null!;

        [Display(Name ="Last Name")]
        [StringLength(LastNameMaxLenght, MinimumLength = LastNameMinLenght, ErrorMessage = "The field '{0}' must be between {2} and {1} characters lenght.")]
        public string LastName { get; set; } = null!;

        public virtual List<AddressViewModel> Addresses { get; set; }

        [Display(Name ="Vat Number")]
        [StringLength(VatNumberMaxLenght, MinimumLength = VatNumberMinLenght, ErrorMessage = "The field '{0}' must be between {2} and {1} characters lenght.")]
        public string VatNumber { get; set; } = null!;

        [Required]
        [Display(Name = "Client")]
        public bool IsClient { get; set; } = true;

        [Required]
        [Display(Name = "Supplier")]
        public bool IsSupplier { get; set; } = false;

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
