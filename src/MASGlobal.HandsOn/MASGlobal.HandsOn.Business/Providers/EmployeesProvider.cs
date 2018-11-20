using MASGlobal.HandsOn.Business.Providers.Contracts;
using MASGlobal.HandsOn.Model.Dtos;
using MASGlobal.HandsOn.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace MASGlobal.HandsOn.Business.Providers
{
    public class EmployeesProvider : IEmployeesProvider
    {
        readonly IEmployeesRepository _repository;
        public EmployeesProvider(IEmployeesRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _repository.Get<Employee>();
        }

        public IEnumerable<Employee> GetEmployee(int id)
        {
            var employees = _repository.Get<Employee>();
            return employees != null && employees.Any() ? employees.Where(x => x.Id == id) : null;
        }
    }
}
