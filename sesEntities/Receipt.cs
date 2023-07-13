using sesEntities.TypeConverters;
using System.ComponentModel;

namespace sesEntities
{
    [TypeConverter(typeof(ReceiptTypeConverter))]
    public class Receipt
    {
        public DateTime timestamp { get; set; }
        public int processingTimeMillis { get; set; }
        public List<string> recipients { get; set; }
        public SpamVerdict spamVerdict { get; set; }
        public VirusVerdict virusVerdict { get; set; }
        public SpfVerdict spfVerdict { get; set; }
        public DkimVerdict dkimVerdict { get; set; }
        public DmarcVerdict dmarcVerdict { get; set; }
        public string dmarcPolicy { get; set; }
        public Action action { get; set; }
    }
}
