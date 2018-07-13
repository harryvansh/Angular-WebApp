using System.Collections.Generic;
using System.Threading.Tasks;
using Angular_WebApp.Models;

namespace Angular_WebApp.Controllers.Repository
{
    public interface IEmployeeRepo
    {
        Task<List<Employee>> GetAllAsync();

    }
}