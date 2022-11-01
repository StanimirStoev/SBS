

using System.Reflection;

namespace SBS.Tools
{
    public enum SortOrder { Ascending = 0, Descending = 1 }
    public class SortHelper
    {
        private string upIcon = "fa fa-arrow-up";
        private string downIcon = "fa fa-arrow-down";
        public string SortedProperty { get; set; }

        public SortOrder SortedOrder { get; set; }

        public string SortExperssion { get; set; }
        public string SortedExperssion { get; private set; }

        private List<SortableColumn> sortableColumns = new List<SortableColumn>();

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
        public SortableColumn GetColumn(string columnName)
        {
            SortableColumn tmp = this.sortableColumns
                .Where(c => c.ColumnName.ToLower() == columnName.ToLower())
                .SingleOrDefault();
            if (tmp == null)
            {
                this.sortableColumns.Add(new SortableColumn() { ColumnName = columnName });
            }
            return tmp;
        }

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

    public class SortableColumn
    {
        public string ColumnName { get; set; }

        public string SortExpression { get; set; }

        public string SortIcon { get; set; }
    }
}
