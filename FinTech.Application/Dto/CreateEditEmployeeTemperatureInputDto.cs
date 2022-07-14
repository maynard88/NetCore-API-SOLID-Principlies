using FinTech.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinTech.Application.Dto
{
    public class CreateEditEmployeeTemperatureInputDto : Entity<long>
    {
        [Required]
        public virtual long EmployeeId { get; set; }      

        [Required]
        public decimal Temperature { get; set; }

        [Required]
        public DateTime RecordDate { get; set; }
    }
}
