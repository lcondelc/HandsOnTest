using MASGlobal.HandsOn.Business.Providers;
using MASGlobal.HandsOn.Business.Providers.Contracts;
using MASGlobal.HandsOn.Repository.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace MASGlobal.HandsOn.UnitTests.Business
{
    [TestClass]
    public class EmployeesUnitTest
    {
        private IEmployeesProvider GetProvider()
        {
            var tool = new Tool.Web.WebRequest();
            IEmployeesRepository repository = new Repository.EmployeesRepository(tool);
            return new EmployeesProvider(repository);
        }

        [TestMethod]
        public void Api_Return_Employees()
        {
            var provider = GetProvider();
            var employees = provider.GetEmployees();

            Assert.IsNotNull(employees);
            Assert.IsTrue(employees.Any());
        }

        [TestMethod]
        [DataRow(1, 86400000)]
        [DataRow(2, 960000)]
        public void Employee_Has_Valid_Anual_Salary(int id, double salary)
        {
            var provider = GetProvider();
            var employees = provider.GetEmployee(id);

            Assert.IsNotNull(employees);
            Assert.IsTrue(employees.Any());

            var employee = employees.FirstOrDefault();
            Assert.IsNotNull(employee);

            double anualSalary = 0;
            switch (employee.ContractTypeName)
            {
                case "HourlySalaryEmployee":
                    anualSalary = 120 * employee.HourlySalary * 12;
                    break;
                case "MonthlySalaryEmployee":
                default:
                    anualSalary = employee.MonthlySalary * 12;
                    break;
            }

            Assert.AreEqual(anualSalary, employee.Salary);
        }
    }
}
