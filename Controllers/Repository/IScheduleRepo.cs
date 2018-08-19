using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Angular_WebApp.Models;

namespace Angular_WebApp.Controllers.Repository
{
    public interface IScheduleRepo
    {
        Task<List<Schedule>> GetAllAsync();
        Task<int> PostAsync(Schedule model);
        Task PutAsync(Schedule model);
        Task DeleteAllAsync();
        Task<Schedule> GetScheduleModel(int id);

    }
}