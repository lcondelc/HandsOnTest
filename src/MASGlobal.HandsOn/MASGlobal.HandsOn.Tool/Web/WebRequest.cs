using System;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace MASGlobal.HandsOn.Tool.Web
{
    public class WebRequest : IWebRequest
    {
        public T WebClient<T>(string url)
        {
            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(5);
                var response = client.GetStringAsync(url);
                if (response != null)
                {
                    var javaScriptSerializer = new JavaScriptSerializer();
                    var result = response.Result;
                    return javaScriptSerializer.Deserialize<T>(result);
                }
            }
            return default(T);
        }
    }
}
