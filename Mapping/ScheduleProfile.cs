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
        .ForMember(dest => dest.DateEnd, opts => opts.MapFrom(src => Convert.ToDateTime(src.DateEnd).ToShortDateString()))
        //need to map the other way
        ;
        CreateMap<ScheduleViewModel, Schedule>()
        .ForMember(dest => dest.DateStart, opts => opts.MapFrom(src => Convert.ToDateTime(src.DateStart).ToShortDateString()))
        .ForMember(dest => dest.DateEnd, opts => opts.MapFrom(src => Convert.ToDateTime(src.DateEnd).ToShortDateString()))
        .ForMember(dest => dest.Day, opts => opts.MapFrom(src => convertDays(src.Days)))
        ;
    }

    private string convertDays(Days daysModel)
    {
        string result = "";
        if(daysModel.Monday)
        {
            result += "Mon,";
        }
        if(daysModel.Tuesday)
        {
            result += "Tues,";
        }
        if(daysModel.Wednesday)
        {
            result += "Wed,";
        }
        if(daysModel.Thursday)
        {
            result += "Thur,";
        }
        if(daysModel.Friday)
        {
            result += "Fri,";
        }
        if(daysModel.Saturday)
        {
            result += "Sat,";
        }
        if(daysModel.Sunday)
        {
            result += "Sun,";
        }

        return result.TrimEnd(',');
    }
           
    }
}