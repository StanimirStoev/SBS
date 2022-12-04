namespace SBS.Tools
{
    /// <summary>
    /// List that can be paginate
    /// </summary>
    /// <typeparam name="T">Type of data in the list</typeparam>
    public class PaginatedList <T> : List<T>
    {
        /// <summary>
        /// Total reords of source list
        /// </summary>
        public int TotalRecords { get; private set; }
        /// <summary>
        /// Initialise list. Represent the list of page.
        /// </summary>
        /// <param name="source">Source list of data</param>
        /// <param name="pageIndex">Index of the page to be shown</param>
        /// <param name="pageSize">Size of the page to be shown</param>
        public PaginatedList(List<T> source, int pageIndex, int pageSize)
        {
            TotalRecords = source.Count;
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            this.AddRange(items);
        }
    }
}
