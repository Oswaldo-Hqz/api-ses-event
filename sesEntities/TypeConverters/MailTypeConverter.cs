using System.ComponentModel;
using System.Globalization;

namespace sesEntities.TypeConverters
{
    public class MailTypeConverter: TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
        {
            return destinationType == typeof(Mail);
        }

        public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
        {
            var mail = value as Mail;
            return new JsonResponse
            {
                mes = mail.timestamp.ToString("MMMM"),
                emisor = mail.source.Substring(0, mail.source.IndexOf("@")),
                receptor = mail.destination.Select(email => email.Substring(0, email.IndexOf("@"))).ToList()
            };
        }
    }
}
