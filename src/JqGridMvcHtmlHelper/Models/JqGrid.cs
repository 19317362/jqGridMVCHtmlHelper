using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace JqGridMvcHtmlHelper.Models
{
    public class JqGrid<T>
    {
        public bool IsSearch;

        public string SortColumn;

        public string SortOrder;

        public int PageNo;

        public int PageSize;

        public int TotalRecords;

        public int PageCount;

        public JqGridFilter Filter;

        public IQueryable<T> List;

        public int PageIndex
        {
            get
            {
                return Convert.ToInt32(this.PageNo) - 1;
            }
        }


        public JqGrid(bool search, string sidx, string sord, int page, int rows, string filters)
        {
            this.IsSearch = Convert.ToBoolean(search);
            this.SortColumn = sidx;
            this.SortOrder = sord;
            this.PageNo = page;
            this.PageSize = rows;
            this.Filter = PopulateFilter(filters);
        }

        public static JqGridFilter PopulateFilter(string jsonData)
        {
            try
            {
                if (string.IsNullOrEmpty(jsonData))
                {
                    return null;
                }
                var serializer = new DataContractJsonSerializer(typeof(JqGridFilter));
                new StringReader(jsonData);
                var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonData));
                return serializer.ReadObject(ms) as JqGridFilter;
            }
            catch
            {
                return null;
            }
        }
    }
}