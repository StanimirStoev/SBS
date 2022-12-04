using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SBS.Infrastructure.Constants.DataConstants.City;

namespace SBS.Infrastructure.Data.Models
{
    /// <summary>
    /// Data for a City
    /// </summary>
    [Comment("Data for a City")]
    public class City
    {
        /// <summary>
        /// Init new city
        /// </summary>
        public City()
        {
            Addresses = new HashSet<Address>();
        }

        /// <summary>
        /// City Identifier
        /// </summary>
        [Key]
        [Comment("City Identifier")]
        public Guid Id { get; set; }

        /// <summary>
        /// Name of City
        /// </summary>
        [Required]
        [StringLength(NameMaxLenght)]
        [Comment("Name of City")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Country Identifier
        /// </summary>
        [Required]
        [Comment("Country Identifier")]
        public Guid CountryId { get; set; }

        /// <summary>
        /// Countri data
        /// </summary>
        [ForeignKey(nameof(CountryId))]
        public virtual Country Country { get; set; } = null!;

        /// <summary>
        /// List of Addresses
        /// </summary>
        public virtual ICollection<Address> Addresses { get; set; }

        /// <summary>
        /// Flag for deleted/in use 
        /// </summary>
        [Required]
        [Comment("Flag for deleted/in use ")]
        public bool IsActive { get; set; } = true;

    }
}
