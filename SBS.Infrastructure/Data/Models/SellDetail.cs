using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Infrastructure.Data.Models
{
    public class SellDetail
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid SellId { get; set; }
        [ForeignKey(nameof(SellId))]
        public virtual Sell Sell { get; set; } = null!;

        [Required]
        //[ForeignKey(nameof(PartidesInStore))]
        public Guid StoreId { get; set; }
        [Required]
        //[ForeignKey(nameof(PartidesInStore))]
        public Guid DeliveryDetailId { get; set; }
        [ForeignKey("StoreId, DeliveryDetailId")]
        public virtual PartidesInStore PartidesInStore { get; set; } = null!;

        [Required]
        public Guid UnitId { get; set; }
        [ForeignKey(nameof(UnitId))]
        public virtual Unit Unit { get; set; } = null!;

        [Required]
        public double Qty { get; set; } = 0;

        [Required]
        public double Price { get; set; } = 0;

        public virtual ICollection<PartidesInStore> PartidesInStores { get; set; } = new HashSet<PartidesInStore>();

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
