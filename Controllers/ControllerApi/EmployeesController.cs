using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Angular_WebApp.Controllers.Logic;
using Angular_WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Angular_WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeLogic _logic;

        public EmployeesController(IEmployeeLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployeesAsync()
        {
            try
            {

                var employees = await _logic.GetAllAsync();

                if (employees == null)
                {
                    return NotFound();
                }
                return employees;
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }

}
        
    }
}