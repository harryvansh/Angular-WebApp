using System.Collections.Generic;
using System.Threading.Tasks;
using Angular_WebApp.Models;

namespace Angular_WebApp.Controllers.Logic
{
    public interface IEmployeeLogic
    {
         Task<List<Employee>> GetAllAsync();
         Task PostAsync(Employee model);
         Task PutAsync(Employee model);
    }
}