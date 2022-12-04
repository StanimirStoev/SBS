using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SBS.Infrastructure.Constants.DataConstants.Address;

namespace SBS.Infrastructure.Data.Models
{
    /// <summary>
    /// Data for a Address
    /// </summary>
    [Comment("Data for a Address")]
    public class Address
    {
        /// <summary>
        /// Address Identifier
        /// </summary>
        [Key]
        [Comment("Address Identifier")]
        public Guid Id { get; set; }

        /// <summary>
        /// Country Identifier
        /// </summary>
        [Required]
        [Comment("Country Identifier")]
        public Guid CountryId { get; set; }
        /// <summary>
        /// Country data
        /// </summary>
        [ForeignKey(nameof(CountryId))]
        public virtual Country Country { get; set; } = null!;

        /// <summary>
        /// City Identifier
        /// </summary>
        [Required]
        [Comment("City Identifier")]
        public Guid CityId { get; set; }
        /// <summary>
        /// City data
        /// </summary>
        [ForeignKey(nameof(CityId))]
        public virtual City City { get; set; } = null!;

        /// <summary>
        ///  Line 1 of Address
        /// </summary>
        [StringLength(AddressLineMaxLenght)]
        [Comment("Address Line 1 of Article")]
        public string AddressLine1 { get; set; } = null!;
        /// <summary>
        ///  Line 2 of Address
        /// </summary>
        [StringLength(AddressLineMaxLenght)]
        [Comment("Address Line 2 of Article")]
        public string AddressLine2 { get; set; } = null!;

        /// <summary>
        /// Contragent Identifier
        /// </summary>
        [Comment("Contragent Identifier")]
        public Guid? ContragentId { get; set; }
        /// <summary>
        /// Contragent data
        /// </summary>
        [ForeignKey(nameof(ContragentId))]
        public virtual Contragent? Contragent { get; set; }

        /// <summary>
        /// Flag for deleted/in use 
        /// </summary>
        [Required]
        [Comment("Flag for deleted/in use ")]
        public bool IsActive { get; set; } = true;
    }
}
