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

        public List<RoleViewModel> Roles { get; set; } = new List<RoleViewModel>();
    }
}
