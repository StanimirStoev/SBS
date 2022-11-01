using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SBS.Infrastructure.Data.Models.Account
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(32)]
        public string? FirstName { get; set; }

        [StringLength(32)]
        public string? LastName { get; set; }
    }
}
