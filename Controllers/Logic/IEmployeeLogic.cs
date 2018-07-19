using System.Collections.Generic;
using System.Threading.Tasks;
using Angular_WebApp.Models;
using Angular_WebApp.ViewModels;

namespace Angular_WebApp.Controllers.Logic
{
    public interface IEmployeeLogic
    {
         Task<List<EmployeeViewModel>> GetAllAsync();
         Task PostAsync(EmployeeViewModel model);
         Task PutAsync(EmployeeViewModel model);
         Task DeleteAllAsync();
    }
}