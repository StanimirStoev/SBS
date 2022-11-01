
using System.ComponentModel.DataAnnotations;
using static SBS.Core.Constants.DataConstants.Unit;

namespace SBS.Core.Models
{
    public class UnitFilterViewModel
    {
        [StringLength(NameMaxLenght)]
        public string Name { get; set; } = null!;

        [StringLength(DescriptionMaxLenght)]
        public string Description { get; set; } = null!;
    }
}
