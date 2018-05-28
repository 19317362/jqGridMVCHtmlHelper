using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JqGridMvcHtmlHelper.Enums;

namespace JqGridMvcHtmlHelper
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
        /*
        public string Pager { get; set; }
        public int RowNum { get; set; }
        public string[] RowList { get; set; }
        public string Sortname { get; set; }
        public string Sortorder { get; set; }
        public bool Viewrecords { get; set; }
        public string Caption { get; set; }
        public Dictionary<string, string> Locale { get; set; }
        public Direction Direction { get; set; }
        public NavGrid NavGrid { get; set; }
        public bool Multiselect { get; set; }
        public string Regional { get; set; }
        */
    }
}
