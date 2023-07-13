using System.ComponentModel;
using System.Globalization;

namespace sesEntities.TypeConverters
{
    public class SpamVerdictTypeConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
        {
            return destinationType == typeof(SpamVerdict);
        }

        public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
        {
            var Spam = value as SpamVerdict;
            return new JsonResponse
            {
                spam = Spam.status == "PASS" ? true : false
            };
        }
    }
}
