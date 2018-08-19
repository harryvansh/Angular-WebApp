using System;
using Angular_WebApp.Models;
using Angular_WebApp.ViewModels;
using AutoMapper;

namespace Angular_WebApp.Mapping
{
    public class ScheduleProfile : Profile 
    {
    public ScheduleProfile() 
    {
        // Add as many of these lines as you need to map your objects
        CreateMap<Schedule, ScheduleViewModel>()
        .ForMember(dest => dest.DateStart, opts => opts.MapFrom(src => Convert.ToDateTime(src.DateStart).ToShortDateString()))
        .ForMember(dest => dest.DateEnd, opts => opts.MapFrom(src => Convert.ToDateTime(src.DateEnd).ToShortDateString()));
        CreateMap<ScheduleViewModel, Schedule>()
        .ForMember(dest => dest.DateStart, opts => opts.MapFrom(src => Convert.ToDateTime(src.DateStart).ToShortDateString()))
        .ForMember(dest => dest.DateEnd, opts => opts.MapFrom(src => Convert.ToDateTime(src.DateEnd).ToShortDateString()));
    }
           
    }
}