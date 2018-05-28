using System;
using System.Runtime.Serialization;

namespace JqGridMvcHtmlHelper
{
    [DataContract]
    public class JqGridFilter
    {
        [DataMember]
        public string GroupOp { get; set; }

        [DataMember]
        public JqGridRule[] Rules { get; set; }

        public GrpOperation GroupOpEnum
        {
            get
            {
                return (GrpOperation)Enum.Parse(typeof(GrpOperation), GroupOp, true);
            }
        }

        private static readonly string[] FormatMapping =
            {
                "(it.{0} = @p{1})", // "eq" - equal
                "(it.{0} <> @p{1})", // "ne" - not equal
                "(it.{0} < @p{1})", // "lt" - less than
                "(it.{0} <= @p{1})", // "le" - less than or equal to
                "(it.{0} > @p{1})", // "gt" - greater than
                "(it.{0} >= @p{1})", // "ge" - greater than or equal to
                "(it.{0} LIKE (@p{1}+'%'))", // "bw" - begins with
                "(it.{0} NOT LIKE (@p{1}+'%'))", // "bn" - does not begin with
                "(it.{0} LIKE ('%'+@p{1}))", // "ew" - ends with
                "(it.{0} NOT LIKE ('%'+@p{1}))", // "en" - does not end with
                "(it.{0} LIKE ('%'+@p{1}+'%'))", // "cn" - contains
                "(it.{0} NOT LIKE ('%'+@p{1}+'%'))" // " nc" - does not contain
            };
    }
}