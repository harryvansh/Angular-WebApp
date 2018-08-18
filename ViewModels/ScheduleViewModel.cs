using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Angular_WebApp.Models;

namespace Angular_WebApp.ViewModels
{
    public class ScheduleViewModel
    {
        public int ScheduleId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateStart { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }
        //Consider regex to keep M,T..,F format
        public string Day { get; set; }
        public List<ScheduleTimeViewModel> ScheduleTime { get; set; }

    }
}