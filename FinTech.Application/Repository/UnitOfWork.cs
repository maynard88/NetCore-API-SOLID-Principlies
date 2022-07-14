using FinTech.EntityFrameworkCore.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinTech.Core.FTEntities;

namespace FinTech.Application.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private FinTechDbContext _context;
        private IEmployeeRepository _employee;
        private IEmployeeTemperatureRepository _employeeTemperature;

        public UnitOfWork(FinTechDbContext context)
        {
            this._context = context;

        }

        public IEmployeeRepository Employee{

            get
            {
                if (_employee == null)
                {
                    _employee = new EmployeeRepository(_context);
                }
                return _employee;
            }

        }

        public IEmployeeTemperatureRepository EmployeeTemperature
        {

            get
            {
                if (_employeeTemperature == null)
                {
                    _employeeTemperature = new EmployeeTemperatureRepository(_context);
                }
                return _employeeTemperature;
            }

        }


        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            if (this._context == null)
            {
                return;
            }

            this._context.Dispose();
            this._context = null;
        }

    }
}
