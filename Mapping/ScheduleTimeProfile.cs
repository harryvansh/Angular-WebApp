using Angular_WebApp.Models;
using Angular_WebApp.ViewModels;
using AutoMapper;

namespace Angular_WebApp.Mapping
{
    public class ScheduleTimeProfile : Profile 
    {
    public ScheduleTimeProfile() 
    {
        // Add as many of these lines as you need to map your objects
        CreateMap<ScheduleTime, ScheduleTimeViewModel>();
        CreateMap<ScheduleTimeViewModel, ScheduleTime>();
    }
           
    }
}