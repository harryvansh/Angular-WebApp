using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Angular_WebApp.Models;

namespace Angular_WebApp.Controllers.Repository
{
    public interface IScheduleTimeRepo
    {
        Task<List<ScheduleTime>> GetAllAsync();
        Task PostAsync(List<ScheduleTime> model);
        Task PutAsync(ScheduleTime model);
        Task DeleteAllAsync();
        Task<ScheduleTime> GetScheduleTimeModel(int id);

    }
}