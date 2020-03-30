using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pumox.DataTransferObjects
{
    public class CompanyDto
    {
        public long Id { get; set; }        
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public IEnumerable<EmployeeDto> Employees { get; set; }
    }
}
