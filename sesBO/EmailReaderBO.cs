using MimeKit;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace sesBO
{
    public class EmailReaderBO : IDisposable
    {
        public async Task<string> getEmailJsonBO(string urlEmail)
        {
            using var webClient = new WebClient();
            var emailBytes = await webClient.DownloadDataTaskAsync(urlEmail);
            var emailStream = new MemoryStream(emailBytes);

            var message = await MimeMessage.LoadAsync(emailStream);

            string jsonResult = null;

            //Buscamos el archivo adjunto y obtenemos json
            var jsonAttachment = message.Attachments.FirstOrDefault(x => x.ContentType.MimeType == "application/json");
            if (jsonAttachment != null)
            {
                using var memoryStream = new MemoryStream();
                await jsonAttachment.WriteToAsync(memoryStream);
                memoryStream.Position = 0;
                using var streamReader = new StreamReader(memoryStream);
                jsonResult = await streamReader.ReadToEndAsync();
            }

            // Si no se encuentra archivo adjunto, buscarlo en el cuerpo del correo o en enlace de página web 
            if (string.IsNullOrEmpty(jsonResult))
            {
                var bodyEmail = message.TextBody ?? message.HtmlBody;

                //Revisamos el cuerpo del correo
                if (!string.IsNullOrEmpty(bodyEmail))
                {
                    try
                    {
                        var jObject = JObject.Parse(bodyEmail);
                        jsonResult = jObject.ToString();
                    }
                    catch (JsonReaderException)
                    {
                        jsonResult = null;
                    }
                }

                // Buscamos el json de un enlace adentro cuerpo del correo
                if (!string.IsNullOrEmpty(bodyEmail) && string.IsNullOrEmpty(jsonResult))
                {
                    var LinkStart = bodyEmail.IndexOf("http");
                    if (LinkStart != -1)
                    {
                        var LinkEnd = bodyEmail.IndexOf(" ", LinkStart);
                        if (LinkEnd == -1)
                            LinkEnd = bodyEmail.Length;

                        var link = bodyEmail.Substring(LinkStart, LinkEnd - LinkStart);
                        var wcLink = new WebClient();
                        var linkedPage = await wcLink.DownloadStringTaskAsync(link);

                        if (!string.IsNullOrEmpty(linkedPage))
                        {
                            try
                            {
                                var jObject = JObject.Parse(linkedPage);
                                jsonResult = jObject.ToString();
                            }
                            catch (JsonReaderException)
                            {
                            }
                        }
                    }
                }
            }

            return jsonResult;

        }

        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~EmailReaderBO()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {

        }
        #endregion
    }
}
