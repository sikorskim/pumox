using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pumox.DataTransferObjects
{
    public class CompanyForCreationDto
    {
        [Required]
        [Range(1900, 2020)]
        public int EstablishmentYear { get; set; }
        [Required]
        public string Name { get; set; }
        public IEnumerable<EmployeeDto> Employees { get; set; }
    }
}
