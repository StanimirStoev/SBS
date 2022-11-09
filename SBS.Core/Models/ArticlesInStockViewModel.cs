using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Core.Models
{
    public  class ArticlesInStockViewModel
    {
        [Required]
        [Display(Name = "Model")]
        public string ArticleModel { get; set; } = null!;

        [Required]
        [Display(Name = "Name")]
        public string ArticleName { get; set; } = null!;

        [Required]
        [Display(Name = "Store")]
        public string StoreName { get; set; } = null!;

        [Required]
        [Display(Name = "Quantity")]
        public double Quantity { get; set; }
    }
}
