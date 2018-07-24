using System;
using System.ComponentModel.DataAnnotations;

namespace Angular_WebApp.ViewModels
{
    public class CustomerViewModel
    {
         [Key]
        public int CustomerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PreferredName { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Birthday { get; set; }

        public int EmployeeId{get; set;}
    }
}