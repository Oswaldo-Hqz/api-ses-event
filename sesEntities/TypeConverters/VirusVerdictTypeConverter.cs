using System.ComponentModel;
using System.Globalization;

namespace sesEntities.TypeConverters
{
    public class VirusVerdictTypeConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
        {
            return destinationType == typeof(VirusVerdict);
        }

        public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
        {
            var Virus = value as VirusVerdict;
            return new JsonResponse
            {
                virus = Virus.status == "PASS" ? true : false
            };
        }
    }
}
