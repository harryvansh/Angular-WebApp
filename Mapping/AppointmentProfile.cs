using Angular_WebApp.Models;
using Angular_WebApp.ViewModels;
using AutoMapper;

namespace Angular_WebApp.Mapping
{
    public class AppointmentProfile : Profile 
    {
    public AppointmentProfile() 
    {
        // Add as many of these lines as you need to map your objects
        CreateMap<Appointment, AppointmentViewModel>()
        .ForMember(dest => dest.EmployeeId, opts => opts.MapFrom(src => src.EmployeeId))
        .ForMember(dest => dest.AppointmentTime, opts => opts.MapFrom(src => src.AppointmentTime));
        CreateMap<AppointmentViewModel, Appointment>()
        .ForMember(dest => dest.EmployeeId, opts => opts.MapFrom(src => src.EmployeeId))
        .ForMember(dest => dest.AppointmentTime, opts => opts.MapFrom(src => src.AppointmentTime));

    }
           
    }
}