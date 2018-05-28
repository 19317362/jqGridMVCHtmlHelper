using System.Collections.Generic;
using System.Text;
using JqGridMvcHtmlHelper.Enums;

namespace JqGridMvcHtmlHelper
{
    public partial class Grid
    {
        public string Url { get; set; }
        public DataType Datatype { get; set; }
        public MethodType MethodType { get; set; }
        public IList<string> ColNames { get; set; }
        public IList<Column> ColModel { get; set; }
        public string Pager { get; set; }
        public int RowNum { get; set; }
        public string[] RowList { get; set; }
        public string Sortname { get; set; }
        public string Sortorder { get; set; }
        public bool Viewrecords { get; set; }
        public string Caption { get; set; }
        public Dictionary<string,string> Locale { get; set; }
        public Direction Direction { get; set; }
        public NavGrid NavGrid { get; set; }
        public bool Multiselect { get; set; }
        public string Regional { get; set; }

        public Grid(string url, IList<string> columnNames, IList<Column> columnModel, string sortName, string caption, bool multiSelect, Direction direction, string currentNeutralCulture)
        {
            Url = url;
            Datatype = DataType.Json;
            MethodType = MethodType.Get;
            ColNames = columnNames;
            ColModel = columnModel;
            Pager = null;
            RowNum = 10;
            RowList = new[] { "5", "10", "20", "50", "1000000000:All" };
            Sortname = sortName;
            Sortorder = "desc";
            Viewrecords = true;
            Caption = caption;
            Locale = new Dictionary<string, string>();
            Direction = direction;
            Regional = currentNeutralCulture;
            NavGrid = new NavGrid();
            Multiselect = multiSelect;

            LoadLocaleData();
        }


        public override string ToString()
        {
            // Create javascript
            var script = new StringBuilder();

            // Start script
            script.AppendLine("<script type=\"text/javascript\">");
            script.Append(RenderJavascript());
            script.AppendLine("</script>");

            // Insert grid id where needed (in columns)
            script.Replace("##gridid##", "");

            // Return script + required elements
            return script + RenderHtmlElements();
        }

        public string RenderJavascript()
        {
            return string.Empty;
        }

        public string RenderHtmlElements()
        {
            return string.Empty;
        }

        public string ToHtmlString()
        {
            return ToString();
        }

        private void LoadLocaleData()
        {
            Locale.Add("bottominfo", Resources.RequiredFieldsHint);
            Locale.Add("genericerror", Resources.ProccessingRequestError);
            Locale.Add("servererrorprefix", Resources.ProccessingRequestErrorWithDetails);
            Locale.Add("deleteRowMassgeConfirmation", Resources.ConfirmDeleteRow);
            Locale.Add("deleteRowsMassgeConfirmation", Resources.ConfirmDeleteRows);
            Locale.Add("errorsHoverHint", Resources.ErrorsHoverHint);
        }
    }
}