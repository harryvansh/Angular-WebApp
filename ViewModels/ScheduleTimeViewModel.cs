using System;
using System.ComponentModel.DataAnnotations;

namespace Angular_WebApp.ViewModels
{
    public class ScheduleTimeViewModel
    {
        public int ScheduleTimeId { get; set; }

        [DataType(DataType.Time)]
        public DateTime TimeStart { get; set; }
        
        [DataType(DataType.Time)]
        public DateTime TimeEnd { get; set; }
    }
}