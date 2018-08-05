using System.Collections.Generic;
using System.Threading.Tasks;
using Angular_WebApp.Controllers.Repository;
using Angular_WebApp.Models;
using Angular_WebApp.ViewModels;
using AutoMapper;

namespace Angular_WebApp.Controllers.Logic
{
    public class AppointmentLogic : IAppointmentLogic
    {
        private readonly IAppointmentRepo _repo;
        private readonly ICustomerLogic _custoemrLogic;
        private readonly IMapper _mapper;
        
        public AppointmentLogic(IAppointmentRepo repo, ICustomerLogic customerLogic, IMapper mapper)
        {
            _repo = repo;
            _custoemrLogic = customerLogic;
            _mapper = mapper;
        }

        public async Task<List<AppointmentViewModel>> GetAllAsync()
        {
            var Appointments = await _repo.GetAllAsync();
            var viewAppointments = _mapper.Map<List<AppointmentViewModel>>(Appointments);
            return viewAppointments;
        }
        public async Task PostAsync(AppointmentViewModel viewModel)
        {
            var customerModel = await _repo.GetCustomertModelByName(viewModel.CustomerFirstName, viewModel.CustomerLastName);
            if(customerModel == null)
            {
                var customerViewModel = new CustomerViewModel {
                    CustomerId= 0,
                    FirstName= viewModel.CustomerFirstName,
                    LastName = viewModel.CustomerLastName
                };
                await _custoemrLogic.PostAsync(customerViewModel);
                customerModel = await _repo.GetCustomertModelByName(viewModel.CustomerFirstName, viewModel.CustomerLastName);
            }
            //var employeeModel = await _repo.GetEmployeeModel(viewModel.EmployeeId);
            var model = _mapper.Map<Appointment>(viewModel);
            //model.Employee = employeeModel;
            model.CustomerId = customerModel.CustomerId;
            //model.Customer = customerModel;
            await _repo.PostAsync(model);
        }

        public async Task PutAsync(AppointmentViewModel viewModel)
        {
            var model = _mapper.Map<Appointment>(viewModel);
                        
            await _repo.PutAsync(model);
        }
        public async Task DeleteAllAsync()
        {
            await _repo.DeleteAllAsync();
        }
    }
}