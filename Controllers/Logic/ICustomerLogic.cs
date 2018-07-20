using System.Collections.Generic;
using System.Threading.Tasks;
using Angular_WebApp.Models;
using Angular_WebApp.ViewModels;

namespace Angular_WebApp.Controllers.Logic
{
    public interface ICustomerLogic
    {
         Task<List<CustomerViewModel>> GetAllAsync();
         Task PostAsync(CustomerViewModel model);
         Task PutAsync(CustomerViewModel model);
         Task DeleteAllAsync();
    }
}