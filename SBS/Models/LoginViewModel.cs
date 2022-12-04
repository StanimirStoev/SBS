using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SBS.Models
{
    /// <summary>
    /// Login data
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Email of User
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        /// <summary>
        /// User Pasword
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        /// <summary>
        /// Data for return URL
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public string? ReturnUrl { get; set; }

        /// <summary>
        /// Flag to remember User login data
        /// </summary>
        [Display(Name="Remember me")]
        public bool RememberMe { get; set; }
    }
}
