using System.ComponentModel.DataAnnotations;

namespace SBS.Core.Models
{
    public class CityViewModelEdit : CityViewModelCreate
    {
        [Key]
        public Guid Id { get; set; }

    }
}
