using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Angular_WebApp.Models
{
    public class Schedule
    {
        public int ScheduleId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateStart { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }
        //Consider regex to keep M,T..,F format
        public string Day { get; set; }
        public List<ScheduleTime> ScheduleTime { get; set; }
        
    }
}