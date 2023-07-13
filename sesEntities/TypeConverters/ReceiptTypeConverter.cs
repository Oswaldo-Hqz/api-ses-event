using System.ComponentModel;
using System.Globalization;


namespace sesEntities.TypeConverters
{
    public class ReceiptTypeConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
        {
            return destinationType == typeof(Receipt);
        }

        public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
        {
            var receipt = value as Receipt;
            return new JsonResponse
            {
                dns = receipt.spfVerdict.status == "PASS" &&
                        receipt.dkimVerdict.status == "PASS" &&
                        receipt.dmarcVerdict.status == "PASS" ? true : false,
                retrasado = receipt.processingTimeMillis > 1000 ? true : false
            };
        }
    }
}
