using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SBS.Infrastructure.Constants.DataConstants.Country;

namespace SBS.Infrastructure.Data.Models
{
    /// <summary>
    /// Data for a Country
    /// </summary>
    [Comment("Data for a Country")]
    public class Country
    {
        /// <summary>
        /// Initialise new Country
        /// </summary>
        public Country()
        {
            Cities = new HashSet<City>();
            Addresses = new HashSet<Address>();
        }

        /// <summary>
        /// Country Identifier
        /// </summary>
        [Key]
        [Comment("Country Identifier")]
        public Guid Id { get; set; }

        /// <summary>
        /// Name of Country
        /// </summary>
        [Required]
        [StringLength(NameMaxLenght)]
        [Comment("Name of Country")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Code of Country
        /// </summary>
        [Required]
        [StringLength(CodeMaxLenght)]
        [Comment("Code of Country")]
        public string Code { get; set; } = null!;

        /// <summary>
        /// Flag for EU countries
        /// </summary>
        [Required]
        [Comment("Flag for EU countries")]
        public bool IsEu { get; set; } = false;

        /// <summary>
        /// List of Cities
        /// </summary>
        public virtual ICollection<City> Cities { get; set; }

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
