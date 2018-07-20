using System.Collections.Generic;
using System.Threading.Tasks;
using Angular_WebApp.Controllers.Repository;
using Angular_WebApp.Models;
using Angular_WebApp.ViewModels;
using AutoMapper;

namespace Angular_WebApp.Controllers.Logic
{
    public class CustomerLogic : ICustomerLogic
    {
        private readonly ICustomerRepo _repo;
        private readonly IMapper _mapper;
        
        public CustomerLogic(ICustomerRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<CustomerViewModel>> GetAllAsync()
        {
            var customers = await _repo.GetAllAsync();
            var viewCustomers = _mapper.Map<List<CustomerViewModel>>(customers);
            return viewCustomers;
        }
        public async Task PostAsync(CustomerViewModel viewModel)
        {
            var model = _mapper.Map<Customer>(viewModel);
            await _repo.PostAsync(model);
        }

        public async Task PutAsync(CustomerViewModel viewModel)
        {
            var model = _mapper.Map<Customer>(viewModel);
                        
            await _repo.PutAsync(model);
        }
        public async Task DeleteAllAsync()
        {
            await _repo.DeleteAllAsync();
        }
    }
}