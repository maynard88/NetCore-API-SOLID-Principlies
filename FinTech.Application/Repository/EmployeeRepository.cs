using FinTech.Core.FTEntities;
using FinTech.EntityFrameworkCore.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinTech.Application.Repository
{
    public class EmployeeRepository : Repository<Employee, long> ,IEmployeeRepository
    {
        public EmployeeRepository(FinTechDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
