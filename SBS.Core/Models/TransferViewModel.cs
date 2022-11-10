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
    public class TransferViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Create Date")]
        public DateTime CreateDatetime { get; set; }

        [Required]
        [Display(Name = "From Store")]
        public Guid FromStoreId { get; set; }
        [ForeignKey(nameof(FromStoreId))]
        public virtual StoreViewModel FromStore { get; set; } = null!;

        [Required]
        [Display(Name = "To Store")]
        public Guid ToStoreId { get; set; }
        [ForeignKey(nameof(ToStoreId))]
        public virtual StoreViewModel ToStore { get; set; } = null!;

        public virtual List<TransferDetailViewModel> Details { get; set; } = new List<TransferDetailViewModel>();

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
