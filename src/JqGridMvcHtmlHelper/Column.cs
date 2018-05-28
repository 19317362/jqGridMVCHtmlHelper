namespace JqGridMvcHtmlHelper
{
    public class Column
    {
        public string Name { get; set; }
        public string Index { get; set; }
        public int? Width { get; set; }
        public string Align { get; set; }
        public string Formatter { get; set; }
        public bool Editable { get; set; }
        public Edittype? Edittype { get; set; }
        public Editrules Editrules { get; set; }
        public Formoptions Formoptions { get; set; }
        public Editoptions Editoptions { get; set; }
        public bool Key { get; set; }
        public bool Hidden { get; set; }
        public Formatoptions Formatoptions { get; set; }
        public string Template { get; set; }
        public string Datefmt { get; set; }
        public bool Sortable { get; set; }

        public Column(string name)
            : this(name, null, 0, null)
        {
        }

        public Column(string name, string index)
            : this(name, index, 0, null)
        {
        }

        public Column(string name, string index, int width, string align)
        {
            Name = name;
            Index = index;
            Width = width;
            Align = align;
            Editable = true;
            Sortable = true;
        }
    }
}