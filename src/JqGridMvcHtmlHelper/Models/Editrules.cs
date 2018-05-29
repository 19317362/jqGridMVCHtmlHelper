namespace JqGridMvcHtmlHelper.Models
{
    public class Editrules
    {
        public bool Required { get; set; }
        public bool Edithidden { get; set; }
        public int? MaxLength { get; set; }
        public bool Email { get; set; }
        public int? MinValue { get; set; }
        public int? MaxValue { get; set; }
    }
}