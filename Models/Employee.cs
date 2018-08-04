using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Angular_WebApp.Models
{
    public class Employee : AuditInfo
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string PreferredName { get; set; }
        public List<Appointment> Appointment { get; set; }
    }
}