using sesEntities.TypeConverters;
using System.ComponentModel;

namespace sesEntities
{ 
    [TypeConverter(typeof(VirusVerdictTypeConverter))]
    public class VirusVerdict
    {
        public string status { get; set; }
    }
}
