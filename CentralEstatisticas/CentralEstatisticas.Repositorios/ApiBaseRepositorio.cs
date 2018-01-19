using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;

namespace CentralEstatisticas.Repositorios
{
    public class ApiBaseRepositorio<T>
    {
        private string EnderecoBase { get; set; }

        private string GetAddressToGet(Dictionary<string, object> parametros)
        {
            return parametros == null || parametros.Count == 0 ? EnderecoBase :
                string.Format("{0}?{1}", EnderecoBase, string.Join("&", parametros.Select(
                    c => string.Format("{0}={1}", HttpUtility.UrlEncode(c.Key), ParseToString(c.Value)))));
        }

        internal ApiBaseRepositorio(string urlBase, string rota)
        {
            EnderecoBase = string.Format("{0}{1}", urlBase, rota);
        }

        internal T ExecutarChamadaGet(Dictionary<string, object> parametros)
        {
            using (var client = new WebClient())
            {
                client.UseDefaultCredentials = true;
                client.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
                var resposta = client.DownloadString(GetAddressToGet(parametros));
                return JsonConvert.DeserializeObject<T>(resposta);
            }
        }

        private static string ParseToString(object value)
        {
            string vValue;
            if (value is string)
                vValue = (string)value;
            else if (value is int)
                vValue = ((int)value).ToString();
            else if (value is DateTime)
                vValue = ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
            else if (value is double)
                vValue = ((double)value).ToString("G", CultureInfo.CreateSpecificCulture("en-US"));
            else if (value is bool)
                vValue = ((bool)value ? "true" : "false");
            else if (value == null)
                vValue = "";
            else
                throw new NotImplementedException();

            return HttpUtility.UrlEncode(vValue);
        }
    }
}
