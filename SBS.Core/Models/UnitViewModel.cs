using System.ComponentModel.DataAnnotations;
using static SBS.Core.Constants.DataConstants.Unit;

namespace SBS.Core.Models
{
    public class UnitViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = "The field '{0}' must be between {2} and {1} characters lenght.")]
        public string Name { get; set; }

        [Required]
        [StringLength(DescriptionMaxLenght)]
        public string Description { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
