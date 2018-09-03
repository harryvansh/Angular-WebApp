using System;
using Angular_WebApp.Models;
using Angular_WebApp.ViewModels;
using AutoMapper;

namespace Angular_WebApp.Mapping
{
    public class ScheduleTimeProfile : Profile
    {
        public ScheduleTimeProfile()
        {
            CreateMap<ScheduleTime, ScheduleTimeViewModel>()
        //     .ForMember(dest => dest.TimeStart, opts => opts.MapFrom(src => Convert.ToDateTime(src.TimeStart).ToShortTimeString()))
        // .ForMember(dest => dest.TimeEnd, opts => opts.MapFrom(src => Convert.ToDateTime(src.TimeEnd).ToShortTimeString()))
        ;
            CreateMap<ScheduleTimeViewModel, ScheduleTime>()
            .ForMember(dest => dest.TimeStart, opts => opts.MapFrom(src => Convert.ToDateTime(src.TimeStart).ToShortTimeString()))
        .ForMember(dest => dest.TimeEnd, opts => opts.MapFrom(src => Convert.ToDateTime(src.TimeEnd).ToShortTimeString()));
        }

    }
}