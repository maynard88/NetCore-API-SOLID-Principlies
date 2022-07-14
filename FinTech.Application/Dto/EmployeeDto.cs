using FinTech.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinTech.Application.Dto
{
    public class EmployeeDto : Entity<long>
    {
   
        public string FirstName { get; set; }
  
        public string LastName { get; set; }

        public virtual ICollection<EmployeeTemperatureDto> EmployeeTemperatures { get; set; }
    }
}
