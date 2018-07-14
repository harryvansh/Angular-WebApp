using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Angular_WebApp.Controllers.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly WebAppContext _context;

        public EmployeeRepo(WebAppContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            var employee = await _context.Employees.Where(e => true).ToListAsync();
            return employee;
        }

        public async Task PostAsync(Employee model)
        {
            _context.Employees.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task PutAsync(Employee model)
        {
            _context.Employees.Update(model);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAllAsync()
        {
            var employees = await _context.Employees.Where(e => true).ToListAsync();
            List<Task<Employee>> tasks = new List<Task<Employee>>();

            foreach (var employee in employees)
            {
                tasks.Add(_context.Employees.FindAsync(employee.Id));
            }
            var entities = await Task.WhenAll(tasks);

            foreach(var entity in entities)
            {
                _context.Remove(entity);
            }
            
            await _context.SaveChangesAsync();
        }
    }
}