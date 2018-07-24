using System;
using System.ComponentModel.DataAnnotations;

namespace Angular_WebApp.Models
{
    public class Customer : AuditInfo
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string DisplayName { get; set; }
        public string PreferredName { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Birthday { get; set; }

        public int EmployeeId {get; set;}
        public Employee Employee {get; set;}
    }
}