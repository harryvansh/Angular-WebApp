using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Angular_WebApp.Controllers.Logic;
using Angular_WebApp.Models;
using Angular_WebApp.ViewModels;
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

        [HttpGet("Employee")]
        public async Task<ActionResult<List<EmployeeViewModel>>> GetEmployeesAsync()
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

        [HttpPost("Employee")]
        public async Task<ActionResult> PostEmployeeAsync([FromBody] EmployeeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                await _logic.PostAsync(model);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }

        }

        [HttpPut("UpdateEmployee")]
        public async Task<ActionResult> PutEmployeeAsync([FromBody] EmployeeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                await _logic.PutAsync(model);
                return Ok(model);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        [HttpDelete("DeleteEmployees")]
        public async Task<ActionResult> DeleteEmployeesAsync()
        {
            try
            {
                await _logic.DeleteAllAsync();
                return Ok();
            }
            catch(Exception e)
            {
                return StatusCode(500,e);
            }
            
        }

    }
}