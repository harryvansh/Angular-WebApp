using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Angular_WebApp.Models;

namespace Angular_WebApp.ViewModels
{
    public class ScheduleViewModel
    {
        public int ScheduleId { get; set; }

        public int EmployeeId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MMM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateStart { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MMM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateEnd { get; set; }
        public Days Days { get; set; }
        public List<ScheduleTimeViewModel> ScheduleTime { get; set; }

    }
}