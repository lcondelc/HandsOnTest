namespace MASGlobal.HandsOn.Model.Enums
{
    public enum ContractType
    {
        HourlySalaryEmployee,
        MonthlySalaryEmployee
    }

    public static class ContractTypeNameExtension
    {
        public static ContractType ParseContractType(this string value)
        {
            switch (value)
            {
                case "HourlySalaryEmployee":
                    return ContractType.HourlySalaryEmployee;
                default:
                    return ContractType.MonthlySalaryEmployee;
            }
        }
    }

}
