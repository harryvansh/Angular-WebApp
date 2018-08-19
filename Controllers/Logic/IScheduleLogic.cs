using System.Collections.Generic;
using System.Threading.Tasks;
using Angular_WebApp.Models;
using Angular_WebApp.ViewModels;

namespace Angular_WebApp.Controllers.Logic
{
    public interface IScheduleLogic
    {
         Task<List<ScheduleViewModel>> GetAllAsync();
         Task PostAsync(ScheduleViewModel model);
         Task PutAsync(ScheduleViewModel model);
         Task DeleteAllAsync();
    }
}