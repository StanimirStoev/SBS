using System.ComponentModel.DataAnnotations;
using static SBS.Core.Constants.DataConstants.City;

namespace SBS.Core.Models
{
    public class CityViewModelCreate
    {
        [Required]
        [Display(Name = "City Name")]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = "The field '{0}' must be between {2} and {1} characters lenght.")]
        public string Name { get; set; } = null!;

        private Guid countryId;
        [Required]
        public Guid CountryId
        {
            get { return countryId; }
            set
            {
                countryId = value;
            }
        }
        public virtual List<CountryViewModel> Countries { get; set; } = new List<CountryViewModel>();

    }
}
