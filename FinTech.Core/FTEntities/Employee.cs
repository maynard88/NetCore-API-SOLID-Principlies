using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using FinTech.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace FinTech.Core.FTEntities
{
    [Table("FTEmployees")]
    public class Employee : Entity<long>
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }


        public virtual ICollection<EmployeeTemperature> EmployeeTemperatures { get; set; }

    }
}
