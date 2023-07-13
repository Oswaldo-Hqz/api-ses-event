using sesEntities.TypeConverters;
using System.ComponentModel;

namespace sesEntities
{
    [TypeConverter(typeof(SpamVerdictTypeConverter))]
    public class SpamVerdict
    {
        public string status { get; set; }
    }
}
