using System.ComponentModel.DataAnnotations;

namespace SBS.Areas.Administration.Models
{
    public class RoleViewModel
    {
        [MaxLength(450)]
        public string? Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; } = null!;

        [Required]
        public bool Selected { get; set; } = false;
    }
}
