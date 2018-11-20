using System.Collections.Generic;

namespace MASGlobal.HandsOn.Repository.Contracts
{
    public interface IEmployeesRepository
    {
        IEnumerable<T> Get<T>();
    }
}