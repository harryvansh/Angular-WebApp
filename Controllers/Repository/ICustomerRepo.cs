using System.Collections.Generic;
using System.Threading.Tasks;
using Angular_WebApp.Models;

namespace Angular_WebApp.Controllers.Repository
{
    public interface ICustomerRepo
    {
        Task<List<Customer>> GetAllAsync();
        Task PostAsync(Customer model);
        Task PutAsync(Customer model);
        Task DeleteAllAsync();
        Task<Customer> GetCustomerModel(int id);

    }
}