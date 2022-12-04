using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SBS.Areas.Administration.Models
{
    /// <summary>
    /// Data for a User with rolesRole
    /// </summary>
    public class UserRoleViewModel 
    {
        /// <summary>
        /// User Identifier
        /// </summary>
        [MaxLength(450)]
        public string? Id { get; set; }

        /// <summary>
        /// User Name
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Roles as SelectListItems
        /// </summary>
        public List<SelectListItem> Roles { get; set; } = new List<SelectListItem>();
    }
}
