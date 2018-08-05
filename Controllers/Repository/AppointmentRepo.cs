using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Angular_WebApp.Controllers.Repository
{
    public class AppointmentRepo : IAppointmentRepo
    {
        private readonly WebAppContext _context;

        public AppointmentRepo(WebAppContext context)
        {
            _context = context;
        }

        public async Task<List<Appointment>> GetAllAsync()
        {
            var Appointment = await _context.Appointments.Where(e => true).ToListAsync();
            return Appointment;
        }

        public async Task PostAsync(Appointment model)
        {
            _context.Appointments.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task PutAsync(Appointment model)
        {
            _context.Appointments.Update(model);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAllAsync()
        {
            var Appointments = await _context.Appointments.Where(e => true).ToListAsync();
            List<Task<Appointment>> tasks = new List<Task<Appointment>>();

            foreach (var Appointment in Appointments)
            {
                tasks.Add(_context.Appointments.FindAsync(Appointment.AppointmentId));
            }
            var entities = await Task.WhenAll(tasks);

            foreach(var entity in entities)
            {
                _context.Remove(entity);
            }
            
            await _context.SaveChangesAsync();
        }

        public async Task<Appointment> GetAppointmentModel(int id)
        {
            return await _context.Appointments.Where(c=>c.AppointmentId == id).SingleOrDefaultAsync();
        }
         public async Task<Customer> GetCustomertModelByName(string FirstName, string LastName)
        {
            return await _context.Customers.Where(c=>c.FirstName == FirstName && c.LastName == LastName).SingleOrDefaultAsync();
        }
        public async Task<Employee> GetEmployeeModel(int id)
        {
            return await _context.Employees.Where(c=>c.EmployeeId == id).SingleOrDefaultAsync();
        }
    }
}