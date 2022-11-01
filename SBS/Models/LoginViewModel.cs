using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SBS.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        //[UIHint("Hidden")]
        [HiddenInput(DisplayValue = false)]
        public string? ReturnUrl { get; set; }

        public bool RememberMe { get; set; }
    }
}
