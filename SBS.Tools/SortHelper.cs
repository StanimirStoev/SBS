using System.Reflection;

namespace SBS.Tools
{
    /// <summary>
    /// Sort order types
    /// </summary>
    public enum SortOrder 
    {
        /// <summary>
        /// Ascending sroting type
        /// </summary>
        Ascending = 0,
        /// <summary>
        /// Descending sroting type
        /// </summary>
        Descending = 1 
    }
    /// <summary>
    /// Sorting mechanics
    /// </summary>
    public class SortHelper
    {
        private string upIcon = "fa fa-arrow-up";
        private string downIcon = "fa fa-arrow-down";
        /// <summary>
        /// Name of property for sorting
        /// </summary>
        public string SortedProperty { get; set; } = null!;
        /// <summary>
        /// Order for sorting.
        /// </summary>
        public SortOrder SortedOrder { get; set; }
        /// <summary>
        /// Sort expression
        /// </summary>
        public string SortExperssion { get; set; } = null!;
        /// <summary>
        /// Old sortexpression
        /// </summary>
        public string SortedExperssion { get; private set; } = null!;
        /// <summary>
        /// List of columns that can be sorted
        /// </summary>
        private List<SortableColumn> sortableColumns = new List<SortableColumn>();
        /// <summary>
        /// Add column to sort column list
        /// </summary>
        /// <param name="columnName">Name of the column</param>
        /// <param name="isDefaultColumn">Is the coumn default sort column</param>
        public void AddColumn(string columnName, bool isDefaultColumn = false)
        {
            SortableColumn tmp = this.sortableColumns
                .Where(c => c.ColumnName.ToLower() == columnName.ToLower())
                .SingleOrDefault();
            if (tmp == null)
            {
                this.sortableColumns.Add(new SortableColumn() { ColumnName = columnName });
            }
            if (isDefaultColumn || sortableColumns.Count == 1)
            {
                SortedProperty = columnName;
                SortedOrder = SortOrder.Ascending;
            }
        }
        /// <summary>
        /// Get column by name
        /// </summary>
        /// <param name="columnName">NAme of the column</param>
        /// <returns></returns>
        public SortableColumn GetColumn(string columnName)
        {
            SortableColumn tmp = this.sortableColumns
                .Where(c => c.ColumnName.ToLower() == columnName?.ToLower())
                .SingleOrDefault();
            if (tmp == null)
            {
                this.sortableColumns.Add(new SortableColumn() { ColumnName = columnName });
            }
            return tmp;
        }
        /// <summary>
        /// Apply sorting for the gived items
        /// </summary>
        /// <typeparam name="T">Type of items to sort</typeparam>
        /// <param name="items">List of items to sort</param>
        public void ApplySort<T>(ref List<T> items)
        {
            string sortExpression = SortExperssion;
            if (sortExpression == null)
            {
                sortExpression = string.Empty;
            }
            if (string.IsNullOrWhiteSpace(sortExpression))
            {
                sortExpression = this.SortedProperty;
            }

            sortExpression = sortExpression.ToLower();
            SortedExperssion = sortExpression;

            foreach (SortableColumn sortableColumn in this.sortableColumns)
            {
                sortableColumn.SortIcon = "";
                sortableColumn.SortExpression = sortableColumn.ColumnName;

                if (sortExpression == sortableColumn.ColumnName.ToLower())
                {
                    this.SortedOrder = SortOrder.Ascending;
                    this.SortedProperty = sortableColumn.ColumnName;
                    sortableColumn.SortIcon = downIcon;
                    sortableColumn.SortExpression = sortableColumn.ColumnName + "_desc";


                    PropertyInfo[] propInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    foreach (PropertyInfo propInfo in propInfos)
                    {
                        if(propInfo.Name.ToLower() == SortedProperty.ToLower())
                        {
                            List<T> ts = items.OrderBy(i => propInfo.GetValue(i, null)).ToList();
                            items.Clear();
                            items.AddRange(ts);
                            break;
                        }
                    }

                    
                }
                if (sortExpression == sortableColumn.ColumnName.ToLower() + "_desc")
                {
                    this.SortedOrder = SortOrder.Descending;
                    this.SortedProperty = sortableColumn.ColumnName;
                    sortableColumn.SortIcon = upIcon;
                    sortableColumn.SortExpression = sortableColumn.SortExpression;

                    PropertyInfo[] propInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    foreach (PropertyInfo propInfo in propInfos)
                    {
                        if (propInfo.Name.ToLower() == SortedProperty.ToLower())
                        {
                            List<T> ts = items.OrderByDescending(i => propInfo.GetValue(i, null)).ToList();
                            items.Clear();
                            items.AddRange(ts);
                            break;
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// Data for sortable column
    /// </summary>
    public class SortableColumn
    {
        /// <summary>
        /// Name of the column
        /// </summary>
        public string ColumnName { get; set; } = null!;
        /// <summary>
        /// Expression for sorting
        /// </summary>
        public string SortExpression { get; set; } = null!;
        /// <summary>
        /// Name for sort icon
        /// </summary>
        public string SortIcon { get; set; } = null!;
    }
}
