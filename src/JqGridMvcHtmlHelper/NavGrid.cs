
namespace JqGridMvcHtmlHelper
{
    public class NavGrid
    {
        public NavGrid()
        {
            Add = false;
            Edit = false;
            View = false;
            Del = false;
            Search = false;
        }
        public string Addtext { get; set; }
        public string Edittext { get; set; }
        public string Deltext { get; set; }
        public string Searchtext { get; set; }
        public string Refreshtext { get; set; }
        public string Viewtext { get; set; }
        public bool Add { get; set; }
        public bool Edit { get; set; }
        public bool View { get; set; }
        public bool Del { get; set; }
        public bool Search { get; set; }
        public string Addfunc { get; set; }
    }
}