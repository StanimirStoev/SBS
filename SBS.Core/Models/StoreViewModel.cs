using SBS.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SBS.Core.Constants.DataConstants.Store;

namespace SBS.Core.Models
{
    public  class StoreViewModel
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = "The field '{0}' must be between {2} and {1} characters lenght.")]
        public string Name { get; set; } = null!;

        [StringLength(DescriptionMaxLenght)]
        public string? Description { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public Guid? AddressId { get; set; }
        [ForeignKey(nameof(AddressId))]
        public virtual AddressViewModel? Address { get; set; }

    }
}
