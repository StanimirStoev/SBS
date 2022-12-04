using System.ComponentModel.DataAnnotations;

namespace SBS.Core.Models
{
    /// <summary>
    /// Data for a City
    /// </summary>
    public class CityViewModelEdit : CityViewModelCreate
    {
        /// <summary>
        /// City Identifier
        /// </summary>
        [Key]
        public Guid Id { get; set; }

    }
}
