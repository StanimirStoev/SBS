using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SBS.Infrastructure.Constants.DataConstants.Address;

namespace SBS.Infrastructure.Data.Models
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid CountryId { get; set; }
        [ForeignKey(nameof(CountryId))]
        public virtual Country Country { get; set; } = null!;

        [Required]
        public Guid CityId { get; set; }
        [ForeignKey(nameof(CityId))]
        public virtual City City { get; set; } = null!;

        [StringLength(AddressLineMaxLenght)]
        public string AddressLine1 { get; set; } = null!;
        [StringLength(AddressLineMaxLenght)]
        public string AddressLine2 { get; set; } = null!;

        [Required]
        public bool IsActive { get; set; } = true;

        //public Guid? ContragentId { get; set; }
        //[ForeignKey(nameof(ContragentId))]
        //public virtual Contragent? Contragent { get; set; }

        //public Guid? StoreId { get; set; }
        //[ForeignKey(nameof(StoreId))]
        //public virtual Store? Store { get; set; }

    }
}
