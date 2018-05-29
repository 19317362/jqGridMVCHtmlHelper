using System;
using System.Runtime.Serialization;

namespace JqGridMvcHtmlHelper.Models
{
    [DataContract]
    public class JqGridRule
    {
        [DataMember]
        public string Field { get; set; }

        [DataMember]
        public string Op { get; set; }

        [DataMember]
        public string Data { get; set; }

        public WhereOperation OpEnum
        {
            get
            {
                return (WhereOperation)Enum.Parse(typeof(WhereOperation), Op, true);
            }
        }
    }
}