using System.ComponentModel.DataAnnotations;
using static SBS.Infrastructure.Constants.DataConstants.Country;

namespace SBS.Infrastructure.Data.Models
{
    public class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
            Addresses = new HashSet<Address>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(NameMaxLenght)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(CodeMaxLenght)]
        public string Code { get; set; } = null!;

        [Required]
        public bool IsEu { get; set; } = false;

        public virtual ICollection<City> Cities { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
