using System.ComponentModel.DataAnnotations;

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
