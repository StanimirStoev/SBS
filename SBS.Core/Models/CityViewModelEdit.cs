using System.ComponentModel.DataAnnotations;
using static SBS.Core.Constants.DataConstants.City;

namespace SBS.Core.Models
{
    public class CityViewModelEdit : CityViewModelCreate
    {
        [Key]
        public Guid Id { get; set; }

    }
}
