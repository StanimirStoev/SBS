using System.ComponentModel.DataAnnotations;
using static SBS.Core.Constants.DataConstants.City;

namespace SBS.Core.Models
{
    /// <summary>
    /// Data for a City
    /// </summary>
    public class CityViewModelCreate
    {
        /// <summary>
        /// Name of City
        /// </summary>
        [Required]
        [Display(Name = "City Name")]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = "The field '{0}' must be between {2} and {1} characters lenght.")]
        public string Name { get; set; } = null!;

        private Guid countryId;
        /// <summary>
        /// Country Identifier
        /// </summary>
        [Required]
        public Guid CountryId
        {
            get { return countryId; }
            set
            {
                countryId = value;
            }
        }

        /// <summary>
        /// List of Countries
        /// </summary>
        public virtual List<CountryViewModel> Countries { get; set; } = new List<CountryViewModel>();

    }
}
