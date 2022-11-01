using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SBS.Infrastructure.Constants.DataConstants.Store;

namespace SBS.Infrastructure.Data.Models
{
    public class Store
    {
        public Store()
        {
            PartidesInStores = new HashSet<PartidesInStore>();
        }

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

        public virtual ICollection<PartidesInStore> PartidesInStores { get; set; }
    }
}
