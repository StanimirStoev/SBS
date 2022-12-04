using Microsoft.AspNetCore.Mvc.Rendering;

namespace SBS.Core.Models
{
    /// <summary>
    /// Page data
    /// </summary>
    public class PagerViewModel
    {
        private const int MaxPagesBeforeCurrent = 5;
        private const int MaxPagesAfterCurrent = 4;

        /// <summary>
        /// Count for total items
        /// </summary>
        public int TotalItems { get; private set; }

        /// <summary>
        /// Curen page
        /// </summary>
        public int CurrentPage { get; private set; }

        /// <summary>
        /// Size of the page
        /// </summary>
        public int PageSize { get; private set; }

        /// <summary>
        /// Total pages number
        /// </summary>
        public int TotalPages { get; private set; }

        /// <summary>
        /// Start page
        /// </summary>
        public int StartPage { get; private set; }

        /// <summary>
        /// End page
        /// </summary>
        public int EndPage { get; private set; }

        /// <summary>
        /// Start record
        /// </summary>
        public int StartRecord { get; private set; }

        /// <summary>
        /// End Record
        /// </summary>
        public int EndRecord { get; private set; }

        /// <summary>
        /// Action name
        /// </summary>
        public string Action { get; set; } = "Index";

        /// <summary>
        /// Expression for sorting
        /// </summary>
        public string SortExpression { get; set; }

        /// <summary>
        /// Init page data
        /// </summary>
        /// <param name="totalItems"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        public PagerViewModel(int totalItems, int currentPage, int pageSize = 5)
        {
            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;

            int totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            TotalPages = totalPages;

            int startPage = currentPage - MaxPagesBeforeCurrent;
            int endPage = currentPage + MaxPagesAfterCurrent;

            if (startPage <= 0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }

            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > (MaxPagesBeforeCurrent + MaxPagesAfterCurrent + 1))
                {
                    startPage = endPage - MaxPagesAfterCurrent - MaxPagesBeforeCurrent;
                }
            }

            StartRecord = (CurrentPage - 1) * PageSize + 1;

            EndRecord = StartRecord - 1 + PageSize;

            if(EndRecord > TotalItems)
            {
                EndRecord = TotalItems;
            }

            if(TotalItems == 0)
            {
                StartPage = 0;
                StartRecord = 0;
                CurrentPage = 0;
                EndRecord = 0;
            }
            else
            {
                StartPage = startPage;
                EndPage = endPage;
            }
        }

        /// <summary>
        /// List for page sizes
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetPageSizes()
        {
            var pageSizes = new List<SelectListItem>();

            for(int lp = 5; lp <= 50; lp += 5)
            {
                pageSizes.Add(new SelectListItem(lp.ToString(), lp.ToString(), lp == this.PageSize));

            }
            return pageSizes;
        }
    }
}
