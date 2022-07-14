using FinTech.Core.FTEntities;
using FinTech.EntityFrameworkCore.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinTech.Application.Repository
{
    public class EmployeeTemperatureRepository : Repository<EmployeeTemperature, long> ,IEmployeeTemperatureRepository
    {
        public EmployeeTemperatureRepository(FinTechDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
