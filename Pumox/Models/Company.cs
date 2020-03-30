using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Pumox.Interfaces;

namespace Pumox.Models 
{
    public class Company
    { 
        public long Id { get; set; } 
        public int EstablishmentYear { get; set; }
        public string Name { get; set; }        
        public ICollection<Employee> Employees { get; set; }
    }
}