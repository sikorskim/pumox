using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pumox.Interfaces;

namespace Pumox.Models
{
    public class Employee
    { 
        public long Id { get; set; }        
        public string FirstName { get; set; }        
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public JobTitle JobTitle { get; set; }
        [ForeignKey(nameof(Company))]
        public long CompanyId { get; set; }
        public Company Company { get; set; }
    }
}