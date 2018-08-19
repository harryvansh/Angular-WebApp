using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular_WebApp.Models
{
    public class ScheduleTime : AuditInfo
    {
        public int ScheduleTimeId { get; set; }

        [DataType(DataType.Time)]
        public DateTime TimeStart { get; set; }
        
        [DataType(DataType.Time)]
        public DateTime TimeEnd { get; set; }

        [ForeignKey("Schedule")]
        public int ScheduleId { get; set; }
    }
}