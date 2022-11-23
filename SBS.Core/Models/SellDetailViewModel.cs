using SBS.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Core.Models
{
    public class SellDetailViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid SellId { get; set; }
        [ForeignKey(nameof(SellId))]
        public virtual SellViewModel? Sell { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(PartidesInStore))]
        public Guid StoreId { get; set; }
        [Required]
        [ForeignKey(nameof(PartidesInStore))]
        public Guid DeliveryDetailId { get; set; }

        public virtual PartidesInStore PartidesInStore { get; set; } = null!;

        [Required]
        public double Qty { get; set; } = 0;

        [Required]
        public double Price { get; set; } = 0;

        public double TotalPrice
        {
            get
            {
                return Qty * Price;
            }
        }

        [Required]
        public Guid UnitId { get; set; }
        [ForeignKey(nameof(UnitId))]
        public virtual UnitViewModel? Unit { get; set; } = null!;

        public virtual ICollection<PartidesInStore> PartidesInStores { get; set; } = new HashSet<PartidesInStore>();

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
