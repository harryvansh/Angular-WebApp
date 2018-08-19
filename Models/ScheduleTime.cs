using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular_WebApp.Models
{
    public class ScheduleTime : AuditInfo
    {
        public int ScheduleTimeId { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }

        [ForeignKey("Schedule")]
        public int ScheduleId { get; set; }
    }
}