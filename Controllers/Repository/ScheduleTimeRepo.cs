using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Angular_WebApp.Controllers.Repository
{
    public class ScheduleTimeRepo : IScheduleTimeRepo
    {
        private readonly WebAppContext _context;

        public ScheduleTimeRepo(WebAppContext context)
        {
            _context = context;
        }

        public async Task<List<ScheduleTime>> GetAllAsync()
        {
            var ScheduleTime = await _context.ScheduleTimes.Where(e => true).ToListAsync();
            return ScheduleTime;
        }

        public async Task PostAsync(List<ScheduleTime> models)
        {
            foreach(var model in models)
            {
                await _context.ScheduleTimes.AddAsync(model);
            }
            
            await _context.SaveChangesAsync();
        }

        public async Task PutAsync(ScheduleTime model)
        {
            _context.ScheduleTimes.Update(model);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAllAsync()
        {
            var ScheduleTimes = await _context.ScheduleTimes.Where(e => true).ToListAsync();
            List<Task<ScheduleTime>> tasks = new List<Task<ScheduleTime>>();

            foreach (var ScheduleTime in ScheduleTimes)
            {
                tasks.Add(_context.ScheduleTimes.FindAsync(ScheduleTime.ScheduleTimeId));
            }
            var entities = await Task.WhenAll(tasks);

            foreach(var entity in entities)
            {
                _context.Remove(entity);
            }
            
            await _context.SaveChangesAsync();
        }

        public async Task<ScheduleTime> GetScheduleTimeModel(int id)
        {
            return await _context.ScheduleTimes.Where(c=>c.ScheduleTimeId == id).SingleAsync();
        }

       
    }
}