using System.Linq;

namespace JqGridMvcHtmlHelper.Models
{
    public class JqGridResult<T>
    {
        public int Total { get; set; }
        public int Page { get; set; }
        public int Records { get; set; }
        public IQueryable<T> Rows { get; set; }
}
}