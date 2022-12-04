using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SBS.Infrastructure.Data.Models.Account
{
    /// <summary>
    /// Extended IdentityUser
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// First Name of ApplicationUser
        /// </summary>
        [StringLength(32)]
        [Comment("First Name of ApplicationUser")]
        public string? FirstName { get; set; }
        /// <summary>
        /// Last Name of ApplicationUser
        /// </summary>
        [StringLength(32)]
        [Comment("Last Name of ApplicationUser")]
        public string? LastName { get; set; }
    }
}
