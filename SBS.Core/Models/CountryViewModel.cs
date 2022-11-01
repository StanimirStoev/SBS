using System.ComponentModel.DataAnnotations;
using static SBS.Core.Constants.DataConstants.Country;

namespace SBS.Core.Models
{
    public class CountryViewModel
    {
        public CountryViewModel()
        {
            Cities = new HashSet<CityViewModel>();
            //Addresses = new HashSet<Address>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Country Name")]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = "The field '{0}' must be between {2} and {1} characters lenght.")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(CodeMaxLenght, ErrorMessage = "The field '{0}' can contains max {1} characters.")]
        public string Code { get; set; } = null!;

        [Required]
        [Display(Name = "EU")]
        public bool IsEu { get; set; } = false;

        public virtual ICollection<CityViewModel> Cities { get; set; }

        //public virtual ICollection<Address> Addresses { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
