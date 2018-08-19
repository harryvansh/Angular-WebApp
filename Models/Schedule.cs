using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Angular_WebApp.Models
{
    public class Schedule : AuditInfo
    {
        public int ScheduleId { get; set; }
        public string DateStart { get; set; }
        public string DateEnd { get; set; }
        //Consider regex to keep M,T..,F format
        public string Day { get; set; }
        public List<ScheduleTime> ScheduleTime { get; set; }

    }
}