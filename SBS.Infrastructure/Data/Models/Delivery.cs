using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Infrastructure.Data.Models
{
    public class Delivery
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ContragentId { get; set; }
        [ForeignKey(nameof(ContragentId))]
        public virtual Contragent Contragent { get; set; } = null!;

        [Required]
        public DateTime CreateDatetime { get; set; }

        [Required]
        public Guid StoreId { get; set; }
        [ForeignKey(nameof(StoreId))]
        public virtual Store Store { get; set; } = null!;
    }
}
