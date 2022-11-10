using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SBS.Infrastructure.Constants.DataConstants.Store;

namespace SBS.Infrastructure.Data.Models
{
    public class Store
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(NameMaxLenght)]
        public string Name { get; set; } = null!;

        [StringLength(DescriptionMaxLenght)]
        public string? Description { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public Guid? AddressId { get; set; }
        [ForeignKey(nameof(AddressId))]
        public virtual Address? Address { get; set; }

        public virtual List<PartidesInStore> PartidesInStores { get; set; } = new List<PartidesInStore>();

        public virtual List<Transfer> TransferStoresFrom { get; set; } = new List<Transfer>();

        public virtual List<Transfer> TransferStoresTo { get; set; } = new List<Transfer>();
    }
}
