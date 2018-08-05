using System.Collections.Generic;
using System.Threading.Tasks;
using Angular_WebApp.Models;

namespace Angular_WebApp.Controllers.Repository
{
    public interface IAppointmentRepo
    {
        Task<List<Appointment>> GetAllAsync();
        Task PostAsync(Appointment model);
        Task PutAsync(Appointment model);
        Task DeleteAllAsync();
        Task<Appointment> GetAppointmentModel(int id);
        Task<Customer> GetCustomertModelByName(string FirstName, string LastName);
        Task<Employee> GetEmployeeModel(int id);

    }
}