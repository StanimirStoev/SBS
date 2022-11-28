using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SBS.Core.Constants.DataConstants.Address;

namespace SBS.Core.Models
{
    public class AddressViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid CountryId { get; set; }
        [ForeignKey(nameof(CountryId))]
        public virtual CountryViewModel? Country { get; set; } = null!;

        [Required]
        public Guid CityId { get; set; }
        [ForeignKey(nameof(CityId))]
        public virtual CityViewModel? City { get; set; } = null!;

        [StringLength(AddressLineMaxLenght, MinimumLength = AddressLineMinLenght, ErrorMessage = "The field '{0}' must be between {2} and {1} characters lenght.")]
        public string AddressLine1 { get; set; } = null!;

        [StringLength(AddressLineMaxLenght, ErrorMessage = "The field '{0}' must be maximum {1} characters lenght.")]
        public string AddressLine2 { get; set; } = null!;

        [Required]
        public bool IsActive { get; set; } = true;

    }
}
