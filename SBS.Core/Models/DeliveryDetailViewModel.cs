﻿using SBS.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Core.Models
{
    public class DeliveryDetailViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid DeliveryId { get; set; }
        [ForeignKey(nameof(DeliveryId))]
        public virtual Delivery Delivery { get; set; } = null!;

        [Required]
        public Guid ArticleId { get; set; }
        [ForeignKey(nameof(ArticleId))]
        public virtual Article Article { get; set; } = null!;

        [Required]
        public double Qty { get; set; } = 0;

        [Required]
        public double Price { get; set; } = 0;

        public virtual ICollection<PartidesInStore> PartidesInStores { get; set; } = new HashSet<PartidesInStore>();

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
