using System.ComponentModel.DataAnnotations;

namespace Angular_WebApp.Models
{
    public class Employee : AuditInfo
    {
        
        public int Id {get; set;} 
        public string FirstName {get; set;}
        public string MiddleName {get; set;}
        public string LastName {get; set;}
        public string DisplayName {get; set;}
        public string KnownAs {get; set;}
    }
}