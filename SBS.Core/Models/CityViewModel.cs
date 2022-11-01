using Microsoft.AspNetCore.Mvc.Rendering;
using SBS.Core.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SBS.Core.Constants.DataConstants.City;

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
