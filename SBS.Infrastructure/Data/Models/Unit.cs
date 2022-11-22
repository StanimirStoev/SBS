using System.ComponentModel.DataAnnotations;
using static SBS.Infrastructure.Constants.DataConstants.Unit;

namespace SBS.Infrastructure.Data.Models
{
    public class Unit
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(NameMaxLenght)]
        public string Name { get; set; } = null!;

        [StringLength(DescriptionMaxLenght)]
        public string? Description { get; set; }

        public virtual List<DeliveryDetail> DeliveryDetails { get; set; } = new List<DeliveryDetail>();

        public virtual List<SellDetail> SellDetails { get; set; } = new List<SellDetail>();

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
