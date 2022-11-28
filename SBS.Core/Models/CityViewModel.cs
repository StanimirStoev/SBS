using System.ComponentModel.DataAnnotations;

namespace SBS.Core.Models
{
    public class CityViewModel : CityViewModelEdit
    {
       // [ForeignKey(nameof(CountryId))]
        public virtual CountryViewModel Country { get; set; } = null!;

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
