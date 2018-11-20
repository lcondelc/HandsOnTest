using MASGlobal.HandsOn.Repository.Contracts;
using MASGlobal.HandsOn.Tool.Web;
using System.Collections.Generic;
using System.Configuration;

namespace MASGlobal.HandsOn.Repository
{
    public class EmployeesRepository : IEmployeesRepository
    {
        readonly IWebRequest _webRequest;

        public EmployeesRepository(IWebRequest webRequest)
        {
            _webRequest = webRequest;
        }
        public IEnumerable<T> Get<T>()
        {
            return _webRequest.WebClient<IEnumerable<T>>(ConfigurationManager.AppSettings["ApiUrl"]);
        }
    }
}
