namespace SBS.Models
{
    /// <summary>
    /// Data for error page
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Id of requested item
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Flag to show requested Id
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}