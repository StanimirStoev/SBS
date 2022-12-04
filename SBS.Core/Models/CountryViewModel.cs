using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using static SBS.Core.Constants.DataConstants.Country;

namespace SBS.Core.Models
{
    /// <summary>
    /// Data for a Country
    /// </summary>
    public class CountryViewModel
    {
        /// <summary>
        /// Initialise new Country
        /// </summary>
        public CountryViewModel()
        {
            Cities = new HashSet<CityViewModel>();
        }

        /// <summary>
        /// Country Identifier
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Name of Country
        /// </summary>
        [Required]
        [Display(Name = "Country Name")]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = "The field '{0}' must be between {2} and {1} characters lenght.")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Code of Country
        /// </summary>
        [Required]
        [StringLength(CodeMaxLenght, ErrorMessage = "The field '{0}' can contains max {1} characters.")]
        public string Code { get; set; } = null!;

        /// <summary>
        /// Flag for EU countries
        /// </summary>
        [Required]
        [Display(Name = "EU")]
        public bool IsEu { get; set; } = false;

        /// <summary>
        /// List of Cities
        /// </summary>
        public virtual ICollection<CityViewModel> Cities { get; set; }

        /// <summary>
        /// List of Cities as Select list items
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SelectListItem> GetCitiesSelectListItems()
        {
            var result = new List<SelectListItem>();

            result = Cities.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            }).ToList();

            result.Insert(0, new SelectListItem() { Value = "", Text = "Select City" });
            return result;
        }

        /// <summary>
        /// Flag for deleted/in use 
        /// </summary>
        [Required]
        public bool IsActive { get; set; } = true;
    }
}
