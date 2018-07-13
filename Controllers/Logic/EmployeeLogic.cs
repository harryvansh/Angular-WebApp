using System.Collections.Generic;
using System.Threading.Tasks;
using Angular_WebApp.Controllers.Repository;
using Angular_WebApp.Models;

namespace Angular_WebApp.Controllers.Logic
{
    public class EmployeeLogic : IEmployeeLogic
    {
        private readonly IEmployeeRepo _repo;
        
        public EmployeeLogic(IEmployeeRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }
    }
}