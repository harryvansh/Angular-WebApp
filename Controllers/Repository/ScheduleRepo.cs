using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Angular_WebApp.Controllers.Repository
{
    public class ScheduleRepo : IScheduleRepo
    {
        private readonly WebAppContext _context;

        public ScheduleRepo(WebAppContext context)
        {
            _context = context;
        }

        public async Task<List<Schedule>> GetAllAsync()
        {
            var Schedule = await _context.Schedules.Where(e => true).ToListAsync();
            return Schedule;
        }

        public async Task<int> PostAsync(Schedule model)
        {
            _context.Schedules.Add(model);
            await _context.SaveChangesAsync();
            return model.ScheduleId;
        }

        public async Task PutAsync(Schedule model)
        {
            _context.Schedules.Update(model);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAllAsync()
        {
            var Schedules = await _context.Schedules.Where(e => true).ToListAsync();
            List<Task<Schedule>> tasks = new List<Task<Schedule>>();

            foreach (var Schedule in Schedules)
            {
                tasks.Add(_context.Schedules.FindAsync(Schedule.ScheduleId));
            }
            var entities = await Task.WhenAll(tasks);

            foreach(var entity in entities)
            {
                _context.Remove(entity);
            }
            
            await _context.SaveChangesAsync();
        }

        public async Task<Schedule> GetScheduleModel(int id)
        {
            return await _context.Schedules.Where(c=>c.ScheduleId == id).SingleAsync();
        }

       
    }
}