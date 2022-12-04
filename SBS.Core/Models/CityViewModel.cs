using System.ComponentModel.DataAnnotations;

namespace SBS.Core.Models
{
    /// <summary>
    /// Data for a City
    /// </summary>
    public class CityViewModel : CityViewModelEdit
    {
        /// <summary>
        /// Countri data
        /// </summary>
        public virtual CountryViewModel Country { get; set; } = null!;

        /// <summary>
        /// Flag for deleted/in use 
        /// </summary>
        [Required]
        public bool IsActive { get; set; } = true;
    }
}
