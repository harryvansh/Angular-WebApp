using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Angular_WebApp.Models
{
    public class Employee : AuditInfo
    {
        
        public int EmployeeId {get; set;} 
        public string FirstName {get; set;}
        public string MiddleName {get; set;}
        public string LastName {get; set;}
        public string DisplayName {get; set;}
        public string KnownAs {get; set;}
        public List<Customer> Customer {get; set;}
    }
}