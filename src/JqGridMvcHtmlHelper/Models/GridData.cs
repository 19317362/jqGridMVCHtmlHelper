namespace JqGridMvcHtmlHelper.Models
{
    public class GridData
    {
        public int Total { get; set; }
        public int Page { get; set; }
        public int Records { get; set; }
        public Row[] Rows { get; set; }

        public GridData(int total, int page, int records, Row[] rows)
        {
            Total = total;
            Page = page;
            Records = records;
            Rows = rows;
        }
    }
}