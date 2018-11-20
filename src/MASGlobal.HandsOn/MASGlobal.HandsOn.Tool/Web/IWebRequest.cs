using System.Collections.Generic;

namespace MASGlobal.HandsOn.Tool.Web
{
    public interface IWebRequest
    {
        T WebClient<T>(string url);
    }
}