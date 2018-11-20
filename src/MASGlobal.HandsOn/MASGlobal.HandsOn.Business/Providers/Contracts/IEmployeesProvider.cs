using MASGlobal.HandsOn.Model.Dtos;
using System.Collections.Generic;

namespace MASGlobal.HandsOn.Business.Providers.Contracts
{
    public interface IEmployeesProvider
    {
        IEnumerable<Employee> GetEmployee(int id);
        IEnumerable<Employee> GetEmployees();
    }
}