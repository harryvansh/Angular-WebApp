using System;
using System.Collections.Generic;
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
        public DateTime Birthday { get; set; }
        public List<Appointment> Appointment { get; set; }
    }
}