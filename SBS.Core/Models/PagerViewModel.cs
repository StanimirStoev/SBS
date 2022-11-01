using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Core.Models
{
    public class PagerViewModel
    {
        private const int MaxPagesBeforeCurrent = 5;
        private const int MaxPagesAfterCurrent = 4;
        public int TotalItems { get; private set; }

        public int CurrentPage { get; private set; }

        public int PageSize { get; private set; }

        public int TotalPages { get; private set; }

        public int StartPage { get; private set; }

        public int EndPage { get; private set; }

        public int StartRecord { get; private set; }

        public int EndRecord { get; private set; }

        public string Action { get; set; } = "Index";

        public string SortExpression { get; set; }

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

        public List<SelectListItem> GetPageSizes()
        {
            var pageSizes = new List<SelectListItem>();

            for(int lp =5; lp <= 50; lp +=5)
            {
                pageSizes.Add(new SelectListItem(lp.ToString(), lp.ToString(), lp == this.PageSize));

            }
            return pageSizes;
        }
    }
}
