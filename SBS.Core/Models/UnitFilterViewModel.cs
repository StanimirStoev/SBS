
using System.ComponentModel.DataAnnotations;
using static SBS.Core.Constants.DataConstants.Unit;

namespace SBS.Core.Models
{
    /// <summary>
    /// Data for Unit fiter
    /// </summary>
    public class UnitFilterViewModel
    {
        /// <summary>
        /// Unit Filter Name
        /// </summary>
        [StringLength(NameMaxLenght)]
        public string Name { get; set; } = null!;
        /// <summary>
        /// Unit Filter Description
        /// </summary>
        [StringLength(DescriptionMaxLenght)]
        public string Description { get; set; } = null!;
    }
}
