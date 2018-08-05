using System.Collections.Generic;
using System.Threading.Tasks;
using Angular_WebApp.Models;
using Angular_WebApp.ViewModels;

namespace Angular_WebApp.Controllers.Logic
{
    public interface IAppointmentLogic
    {
         Task<List<AppointmentViewModel>> GetAllAsync();
         Task PostAsync(AppointmentViewModel model);
         Task PutAsync(AppointmentViewModel model);
         Task DeleteAllAsync();
    }
}