using System;
using System.ComponentModel.DataAnnotations;

namespace Angular_WebApp.Models
{
    public class AuditInfo
    {
        public DateTime CreatedDate {get; set;}
        public DateTime UpdatedDate {get; set;}
        public DateTime DeletedDate {get; set;}
        public Boolean IsDeleted {get; set;}
    }
}