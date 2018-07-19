using Angular_WebApp.Models;
using Angular_WebApp.ViewModels;
using AutoMapper;

namespace Angular_WebApp.Mapping
{
    public class EmployeeProfile : Profile 
    {
    public EmployeeProfile() 
    {
        // Add as many of these lines as you need to map your objects
        CreateMap<Employee, EmployeeViewModel>();
        CreateMap<EmployeeViewModel, Employee>();
    }
           
    }
}