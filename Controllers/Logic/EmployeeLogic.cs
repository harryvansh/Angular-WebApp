using System.Collections.Generic;
using System.Threading.Tasks;
using Angular_WebApp.Controllers.Repository;
using Angular_WebApp.Models;
using Angular_WebApp.ViewModels;
using AutoMapper;

namespace Angular_WebApp.Controllers.Logic
{
    public class EmployeeLogic : IEmployeeLogic
    {
        private readonly IEmployeeRepo _repo;
        private readonly IMapper _mapper;
        
        public EmployeeLogic(IEmployeeRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

         public async Task<EmployeeViewModel> GetEmployeeByIdAsync(int employeeId)
        {
            var employee = await _repo.GetEmployeeByIdAsync(employeeId);
            var viewEmployee = _mapper.Map<EmployeeViewModel>(employee);
            return viewEmployee;
        }

        public async Task<List<EmployeeViewModel>> GetAllAsync()
        {
            var employees = await _repo.GetAllAsync();
            var viewEmployees = _mapper.Map<List<EmployeeViewModel>>(employees);
            return viewEmployees;
        }
        public async Task PostAsync(EmployeeViewModel viewModel)
        {
            var model = _mapper.Map<Employee>(viewModel);
            await _repo.PostAsync(model);
        }

        public async Task PutAsync(EmployeeViewModel viewModel)
        {
            var model = _mapper.Map<Employee>(viewModel);
                        
            await _repo.PutAsync(model);
        }
        public async Task DeleteAllAsync()
        {
            await _repo.DeleteAllAsync();
        }
    }
}