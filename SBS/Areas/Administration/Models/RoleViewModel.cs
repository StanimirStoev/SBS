using System.ComponentModel.DataAnnotations;

namespace SBS.Areas.Administration.Models
{
    /// <summary>
    /// Role data
    /// </summary>
    public class RoleViewModel
    {
        /// <summary>
        /// Role Identifier
        /// </summary>
        [MaxLength(450)]
        public string? Id { get; set; }

        /// <summary>
        /// Role Name
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Flag for Role is selected
        /// </summary>
        [Required]
        public bool Selected { get; set; } = false;
    }
}
