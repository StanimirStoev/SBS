using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SBS.Core.Constants.DataConstants.Address;

namespace SBS.Core.Models
{
    /// <summary>
    /// Data for a Address
    /// </summary>
    public class AddressViewModel
    {
        /// <summary>
        /// Address Identifier
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Country Identifier
        /// </summary>
        [Required]
        public Guid CountryId { get; set; }
        /// <summary>
        /// Country data
        /// </summary>
        [ForeignKey(nameof(CountryId))]
        public virtual CountryViewModel? Country { get; set; } = null!;

        /// <summary>
        /// City Identifier
        /// </summary>
        [Required]
        public Guid CityId { get; set; }
        /// <summary>
        /// City data
        /// </summary>
        [ForeignKey(nameof(CityId))]
        public virtual CityViewModel? City { get; set; } = null!;

        /// <summary>
        ///  Line 1 of Address
        /// </summary>
        [StringLength(AddressLineMaxLenght, MinimumLength = AddressLineMinLenght, ErrorMessage = "The field '{0}' must be between {2} and {1} characters lenght.")]
        public string AddressLine1 { get; set; } = null!;

        /// <summary>
        ///  Line 2 of Address
        /// </summary>
        [StringLength(AddressLineMaxLenght, ErrorMessage = "The field '{0}' must be maximum {1} characters lenght.")]
        public string AddressLine2 { get; set; } = null!;

        /// <summary>
        /// Flag for deleted/in use 
        /// </summary>
        [Required]
        public bool IsActive { get; set; } = true;

    }
}
