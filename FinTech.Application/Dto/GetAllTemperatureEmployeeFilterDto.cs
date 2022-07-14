using FinTech.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinTech.Application.Dto
{
    public class GetAllTemperatureEmployeeFilterDto : Entity<long>
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal? TemperatureStartFilter { get; set; }

        public decimal? TemperatureEndFilter { get; set; }

        public DateTime? RecordDateStart { get; set; }

        public DateTime? RecordDateEnd { get; set; }


    }
}
