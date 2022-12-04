using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SBS.Core.Constants.DataConstants.Store;

namespace SBS.Core.Models
{
    /// <summary>
    /// Store Data
    /// </summary>
    public class StoreViewModel
    {
        /// <summary>
        /// Store Identifier
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Store Name
        /// </summary>
        [Required]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = "The field '{0}' must be between {2} and {1} characters lenght.")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Store Description
        /// </summary>
        [StringLength(DescriptionMaxLenght)]
        public string? Description { get; set; }

        /// <summary>
        /// Store Address Identifier
        /// </summary>
        public Guid? AddressId { get; set; }
        /// <summary>
        /// Store Address
        /// </summary>
        [ForeignKey(nameof(AddressId))]
        public virtual AddressViewModel? Address { get; set; }

        /// <summary>
        /// Flag for deleted/in use Store
        /// </summary>
        [Required]
        public bool IsActive { get; set; } = true;
    }
}
