using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Angular_WebApp.Controllers.Repository
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly WebAppContext _context;

        public CustomerRepo(WebAppContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            var customer = await _context.Customers.Where(e => true).ToListAsync();
            return customer;
        }

        public async Task PostAsync(Customer model)
        {
            _context.Customers.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task PutAsync(Customer model)
        {
            _context.Customers.Update(model);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAllAsync()
        {
            var customers = await _context.Customers.Where(e => true).ToListAsync();
            List<Task<Customer>> tasks = new List<Task<Customer>>();

            foreach (var customer in customers)
            {
                tasks.Add(_context.Customers.FindAsync(customer.CustomerId));
            }
            var entities = await Task.WhenAll(tasks);

            foreach(var entity in entities)
            {
                _context.Remove(entity);
            }
            
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomerModel(int id)
        {
            return await _context.Customers.Where(c=>c.CustomerId == id).SingleAsync();
        }
    }
}