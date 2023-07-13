using sesEntities.TypeConverters;
using System.ComponentModel;

namespace sesEntities
{
    [TypeConverter(typeof(MailTypeConverter))]
    public class Mail
    {
        public DateTime timestamp { get; set; }
        public string source { get; set; }
        public string messageId { get; set; }
        public List<string> destination { get; set; }
        public bool headersTruncated { get; set; }
        public List<Header> headers { get; set; }
        public CommonHeaders commonHeaders { get; set; }
    }
}
