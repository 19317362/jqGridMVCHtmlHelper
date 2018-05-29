using System.Collections.Generic;
using JqGridMvcHtmlHelper.Enums;

namespace JqGridMvcHtmlHelper.Models
{
    public partial class Grid
    {
        public Grid WithUrl(string url)
        {
            Url = url;
            return this;
        }

        public Grid WithDataType(DataType dataType)
        {
            Datatype = dataType;
            return this;
        }

        public Grid WithMethodType(MethodType methodType)
        {
            MethodType = methodType;
            return this;
        }

        public Grid AddColumn(Column column)
        {
            ColModel.Add(column);
            return this;
        }

        public Grid AddColumns(IEnumerable<Column> columns)
        {
            foreach (var column in columns)
            {
                AddColumn(column);
            }

            return this;
        }

        public Grid WithPager(string pager)
        {
            Pager = pager;
            return this;
        }

        public Grid WithDefaultRowNumber(int rowNumber)
        {
            RowNum = rowNumber;
            return this;
        }

        public Grid WithRowNumbers(int[] rowNumbers)
        {
            RowList = (string.Join(",", rowNumbers) + ":All").Split(',');
            return this;
        }

        public Grid WithDefaultSorting(string columnName, SortOrder sortOrder = SortOrder.Asc)
        {
            Sortname = columnName;
            Sortorder = sortOrder.ToString().ToLower();
            return this;
        }

        public Grid ShouldViewRecords(bool viewRecords)
        {
            Viewrecords = viewRecords;
            return this;
        }

        public Grid WithCaption(string caption)
        {
            Caption = caption;
            return this;
        }

        public Grid AddLocaleDictionary(Dictionary<string, string> locale)
        {
            foreach (var item in locale)
            {
                AddLocale(item.Key, item.Value);
            }

            return this;
        }

        public Grid AddLocale(string key, string value)
        {
            if (Locale.ContainsKey(key))
            {
                Locale[key] = value;
            }
            else
            {
                Locale.Add(key, value);
            }

            return this;
        }

        public Grid WithDirection(Direction direction)
        {
            Direction = direction;
            return this;
        }

        public Grid WithNavGrid(NavGrid navGrid)
        {
            NavGrid = navGrid;
            return this;
        }

        public Grid ShouldBeMultiSelect(bool isMultiSelect)
        {
            Multiselect = isMultiSelect;
            return this;
        }

        public Grid WithRegional(string regional)
        {
            Regional = regional;
            return this;
        }
    }
}