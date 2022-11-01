using System.ComponentModel.DataAnnotations;
using static SBS.Infrastructure.Constants.DataConstants.Contragent;

namespace SBS.Infrastructure.Data.Models
{
    public  class Contragent
    {
        public Contragent()
        {
            Addresses = new HashSet<Address>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(FirstNameMaxLenght)]
        public string FirstName { get; set; } = null!;

        [StringLength(LastNameMaxLenght)]
        public string LastName { get; set; } = null!;

        public virtual ICollection<Address> Addresses { get; set; }


        [StringLength(VatNumberMaxLenght)]
        public string VatNumber { get; set; } = null!;

        [Required]
        public bool IsClient { get; set; } = true;

        [Required]
        public bool IsSupplier { get; set; } = false;

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
