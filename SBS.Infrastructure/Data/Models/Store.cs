using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SBS.Infrastructure.Constants.DataConstants.Store;

namespace SBS.Infrastructure.Data.Models
{
    /// <summary>
    /// Store Data
    /// </summary>
    [Comment("Store Data")]
    public class Store
    {
        /// <summary>
        /// Store Identifier
        /// </summary>
        [Key]
        [Comment("Store Identifier")]
        public Guid Id { get; set; }

        /// <summary>
        /// Store Name
        /// </summary>
        [Required]
        [StringLength(NameMaxLenght)]
        [Comment("Store Name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Store Description
        /// </summary>
        [StringLength(DescriptionMaxLenght)]
        [Comment("Store Description")]
        public string? Description { get; set; }

        /// <summary>
        /// Store Address Identifier
        /// </summary>
        [Comment("Address Identifier")]
        public Guid? AddressId { get; set; }
        /// <summary>
        /// Store Address
        /// </summary>
        [ForeignKey(nameof(AddressId))]
        public virtual Address? Address { get; set; }

        /// <summary>
        /// Flag for deleted/in use Store
        /// </summary>
        [Required]
        [Comment("Flag for deleted/in use Store")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// List to PartidesInStore
        /// </summary>
        public virtual List<PartidesInStore> PartidesInStores { get; set; } = new List<PartidesInStore>();

        /// <summary>
        /// List to TransferStoresFrom
        /// </summary>
        public virtual List<Transfer> TransferStoresFrom { get; set; } = new List<Transfer>();

        /// <summary>
        /// List to TransferStoresTo
        /// </summary>
        public virtual List<Transfer> TransferStoresTo { get; set; } = new List<Transfer>();
    }
}
