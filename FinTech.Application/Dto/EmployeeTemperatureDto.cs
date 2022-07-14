using FinTech.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinTech.Application.Dto
{
    public class EmployeeTemperatureDto : Entity<long>
    {
      
        public virtual long EmployeeId { get; set; }

        public EmployeeDto EmployeeFk { get; set; }

        public decimal Temperature { get; set; }
     
        public DateTime RecordDate { get; set; }
    }
}
