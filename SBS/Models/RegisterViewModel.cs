using System.ComponentModel.DataAnnotations;

namespace SBS.Models
{
    /// <summary>
    /// Data for User Registrtion
    /// </summary>
    public class RegisterViewModel
    {
        /// <summary>
        /// User Name
        /// </summary>
        [Required]
        public string Username { get; set; } = null!;

        /// <summary>
        /// User Emale
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        /// <summary>
        /// User Pasword
        /// </summary>
        [Required]
        [Compare(nameof(PasswordRepeat))]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        /// <summary>
        /// Repeated Pasword
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string PasswordRepeat { get; set; } = null!;

        /// <summary>
        /// User First Name
        /// </summary>
        [Required]
        [StringLength(36, MinimumLength = 2)]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// User Last Name
        /// </summary>
        [Required]
        [StringLength(36, MinimumLength = 2)]
        public string LastName { get; set; } = null!;
    }
}
