using System;
using System.ComponentModel.DataAnnotations;

namespace Angular_WebApp.ViewModels
{
    public class ScheduleTimeViewModel
    {
        public int ScheduleTimeId { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh.mm tt}", ApplyFormatInEditMode = true)]
        public DateTime TimeStart { get; set; }
        
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh.mm tt}", ApplyFormatInEditMode = true)]
        public DateTime TimeEnd { get; set; }
         public int ScheduleId { get; set; }
    }
}