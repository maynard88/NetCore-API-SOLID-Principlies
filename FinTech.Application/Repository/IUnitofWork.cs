using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinTech.Application.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employee
        {
            get;
        }

        IEmployeeTemperatureRepository EmployeeTemperature
        {
            get;
        }

        Task Save();
    }
}
