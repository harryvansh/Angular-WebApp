using Angular_WebApp.Models;
using Angular_WebApp.ViewModels;
using AutoMapper;

namespace Angular_WebApp.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer,CustomerViewModel>();
            CreateMap<CustomerViewModel,Customer>()
            .ForMember(dest=>dest.DisplayName, opts=>opts.MapFrom(src=> $"{src.FirstName} {src.LastName}"));
        }
    }
}