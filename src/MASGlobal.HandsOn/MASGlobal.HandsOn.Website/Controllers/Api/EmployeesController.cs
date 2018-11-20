using MASGlobal.HandsOn.Business.Providers.Contracts;
using MASGlobal.HandsOn.Model.Dtos;
using System.Collections.Generic;
using System.Web.Http;

namespace MASGlobal.HandsOn.Website.Controllers.Api
{
    public class ServiceController : ApiController
    {
        readonly IEmployeesProvider _employeesProvider;

        public ServiceController(IEmployeesProvider employeesProvider)
        {
            _employeesProvider = employeesProvider;
        }
        // GET api/<controller>
        public IEnumerable<Employee> GetEmployees()
        {
            return _employeesProvider.GetEmployees();
        }

        // GET api/<controller>/5
        public IEnumerable<Employee> GetEmployee(int id)
        {
            return _employeesProvider.GetEmployee(id);
        }
    }
}