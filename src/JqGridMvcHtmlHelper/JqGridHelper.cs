using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JqGridMvcHtmlHelper
{
    public static class JqGridHelper
    {
        public static IHtmlString For(Grid viewModel)
        {
            var htmlBuilder = new StringBuilder();
            htmlBuilder.AppendLine(string.Empty);
            return MvcHtmlString.Create(htmlBuilder.ToString());
        }

        public static IHtmlString Grid(string gridId)
        {
            var htmlBuilder = new StringBuilder();
            htmlBuilder.AppendLine(string.Empty);
            return MvcHtmlString.Create(htmlBuilder.ToString());
        }
    }
}
