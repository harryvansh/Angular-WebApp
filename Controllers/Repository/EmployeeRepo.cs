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
            var employee = await _context.Employees.Where(e=>true).ToListAsync();
            return employee;
        }
    }
}