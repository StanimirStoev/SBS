using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SBS.Infrastructure.Constants.DataConstants.Contragent;

namespace SBS.Infrastructure.Data.Models
{
    /// <summary>
    /// Data for a Contragent (Client or Supplier)
    /// </summary>
    [Comment("Data for a Contragent (Client or Supplier)")]
    public  class Contragent
    {
        /// <summary>
        /// Init new Contragent
        /// </summary>
        public Contragent()
        {
            Addresses = new List<Address>();
        }

        /// <summary>
        /// Contragent Identifier
        /// </summary>
        [Key]
        [Comment("Contragent Identifier")]
        public Guid Id { get; set; }

        /// <summary>
        /// First Name of Contragent
        /// </summary>
        [Required]
        [StringLength(FirstNameMaxLenght)]
        [Comment("First Name of Contragent")]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Last Name of Contragent
        /// </summary>
        [StringLength(LastNameMaxLenght)]
        [Comment("Last Name of Contragent")]
        public string LastName { get; set; } = null!;

        /// <summary>
        /// List os addresses for the contragent
        /// </summary>
        public virtual List<Address> Addresses { get; set; }

        /// <summary>
        /// Vat Number of Contragent (EGN when private person)
        /// </summary>
        [StringLength(VatNumberMaxLenght)]
        [Comment("Vat Number of Contragent (EGN when private person)")]
        public string VatNumber { get; set; } = null!;

        /// <summary>
        /// Flag is the contragent can be client
        /// </summary>
        [Required]
        [Comment("Flag is the contragent can be client")]
        public bool IsClient { get; set; } = true;

        /// <summary>
        /// Flag is the contragent can be supplier
        /// </summary>
        [Required]
        [Comment("Flag is the contragent can be supplier")]
        public bool IsSupplier { get; set; } = false;

        /// <summary>
        /// Flag for deleted/in use 
        /// </summary>
        [Required]
        [Comment("Flag for deleted/in use ")]
        public bool IsActive { get; set; } = true;
    }
}
