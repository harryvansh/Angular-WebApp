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
        .ForMember(dest => dest.Days, opts => opts.MapFrom(src => convertDaysToViewModel(src.Day)))
        //need to map the other way
        ;
        CreateMap<ScheduleViewModel, Schedule>()
        .ForMember(dest => dest.DateStart, opts => opts.MapFrom(src => Convert.ToDateTime(src.DateStart).ToShortDateString()))
        .ForMember(dest => dest.DateEnd, opts => opts.MapFrom(src => Convert.ToDateTime(src.DateEnd).ToShortDateString()))
        .ForMember(dest => dest.Day, opts => opts.MapFrom(src => convertDaysToModel(src.Days)))
        ;
    }

    private string convertDaysToModel(Days daysModel)
    {
        string result = "";
        if(daysModel.Monday)
        {
            result += "Mon,";
        }
        if(daysModel.Tuesday)
        {
            result += "Tue,";
        }
        if(daysModel.Wednesday)
        {
            result += "Wed,";
        }
        if(daysModel.Thursday)
        {
            result += "Thu,";
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

    private Days convertDaysToViewModel(string scheduleDays)
    {
        Days daysModel = new Days();

        var days = scheduleDays.Split(',');

        foreach(var day in days)
        {
            if(day.Equals("Mon"))
            {
                daysModel.Monday = true;
            }
            if(day.Equals("Tue"))
            {
                daysModel.Tuesday = true;
            }
            if(day.Equals("Wed"))
            {
                daysModel.Wednesday = true;
            }
            if(day.Equals("Thur"))
            {
                daysModel.Thursday = true;
            }
            if(day.Equals("Fri"))
            {
                daysModel.Friday = true;
            }
            if(day.Equals("Sat"))
            {
                daysModel.Saturday = true;
            }
            if(day.Equals("Sun"))
            {
                daysModel.Sunday = true;
            }
        }
        return daysModel;        
    }
           
    }
}