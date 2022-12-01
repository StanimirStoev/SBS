using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SBS.Areas.Administration.Models
{
    public class UserRoleViewModel 
    {
        [MaxLength(450)]
        public string? Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; } = null!;

        public List<SelectListItem> Roles { get; set; } = new List<SelectListItem>();
    }
}
