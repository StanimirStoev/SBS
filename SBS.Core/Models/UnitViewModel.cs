using System.ComponentModel.DataAnnotations;
using static SBS.Core.Constants.DataConstants.Unit;

namespace SBS.Core.Models
{
    /// <summary>
    /// Measuring units
    /// </summary>
    public class UnitViewModel
    {
        /// <summary>
        /// Unit Identifier
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// Unit Short Name
        /// </summary>
        [Required]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = "The field '{0}' must be between {2} and {1} characters lenght.")]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Unit Description
        /// </summary>
        [Required]
        [StringLength(DescriptionMaxLenght)]
        public string Description { get; set; }
        /// <summary>
        /// Flag for deleted/in use Unit
        /// </summary>
        [Required]
        public bool IsActive { get; set; } = true;
    }
}
