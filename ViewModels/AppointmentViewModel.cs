using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Angular_WebApp.Models;

namespace Angular_WebApp.ViewModels
{
    public class AppointmentViewModel
    {
        public string CustomerFirstName {get; set;}
        public string CustomerLastName {get; set;}
        public int EmployeeId {get; set;}
        public DateTime AppointmentTime {get; set;}

    }
}