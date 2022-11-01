﻿using System.ComponentModel.DataAnnotations;

namespace SBS.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [Compare(nameof(PasswordRepeat))]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string PasswordRepeat { get; set; } = null!;

        [Required]
        [StringLength(36, MinimumLength = 2)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(36, MinimumLength = 2)]
        public string LastName { get; set; } = null!;
    }
}
