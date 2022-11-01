using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SBS.Infrastructure.Constants.DataConstants.City;

namespace SBS.Infrastructure.Data.Models
{
    public class City
    {
        public City()
        {
            Addresses = new HashSet<Address>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(NameMaxLenght)]
        public string Name { get; set; } = null!;

        [Required]
        public Guid CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        public virtual Country Country { get; set; } = null!;

        [Required]
        public bool IsActive { get; set; } = true;

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
