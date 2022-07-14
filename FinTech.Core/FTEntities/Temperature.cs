using FinTech.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTech.Core.FTEntities
{
    [Table("FTEmployeeTemperature")]
    public class EmployeeTemperature : Entity<long>
    {
        [Required]
        public virtual long EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee EmployeeFk { get; set; }

        [Required]
        public decimal Temperature { get; set; }

        [Required]
        public DateTime RecordDate { get; set; }


    }
}
