using MASGlobal.HandsOn.Model.Enums;
using MASGlobal.HandsOn.Model.Factory;
using Newtonsoft.Json;
using System;

namespace MASGlobal.HandsOn.Model.Dtos
{
    public class Employee : Salary
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "contractTypeName")]
        public string ContractTypeName { get; set; }
        [JsonProperty(PropertyName = "roleId")]
        public int RoleId { get; set; }
        [JsonProperty(PropertyName = "roleName")]
        public string RoleName { get; set; }
        [JsonProperty(PropertyName = "roleDescription")]
        public object RoleDescription { get; set; }
        [JsonProperty(PropertyName = "hourlySalary")]
        public double HourlySalary { get; set; }
        [JsonProperty(PropertyName = "monthlySalary")]
        public double MonthlySalary { get; set; }

        private double _salary;
        [JsonProperty(PropertyName = "annualSalary")]
        public double Salary
        {
            get
            {
                _salary = GetSalary();
                return _salary;
            }
            set { value = _salary; }
        }

        public override double GetSalary()
        {
            switch (ContractTypeName.ParseContractType())
            {
                case ContractType.HourlySalaryEmployee:
                    return 120 * HourlySalary * 12;
                default:
                    return MonthlySalary * 12;
            }
        }

    }

}
