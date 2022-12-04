using System.ComponentModel.DataAnnotations;

namespace SBS.Core.Models
{
    /// <summary>
    /// Data for a Article in stock
    /// </summary>
    public class ArticlesInStockViewModel
    {
        /// <summary>
        /// Model of article
        /// </summary>
        [Required]
        [Display(Name = "Model")]
        public string ArticleModel { get; set; } = null!;

        /// <summary>
        /// Name of Article
        /// </summary>
        [Required]
        [Display(Name = "Name")]
        public string ArticleName { get; set; } = null!;

        /// <summary>
        /// Store name
        /// </summary>
        [Required]
        [Display(Name = "Store")]
        public string StoreName { get; set; } = null!;

        /// <summary>
        /// Quantity
        /// </summary>
        [Required]
        [Display(Name = "Quantity")]
        public double Quantity { get; set; }
    }
}
