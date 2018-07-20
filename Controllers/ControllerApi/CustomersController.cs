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
    public class CustomersController : Controller
    {
        private readonly ICustomerLogic _logic;

        public CustomersController(ICustomerLogic logic)
        {
            _logic = logic;
        }

        [HttpGet("Customer")]
        public async Task<ActionResult<List<CustomerViewModel>>> GetCustomersAsync()
        {
            try
            {

                var customers = await _logic.GetAllAsync();

                if (customers == null)
                {
                    return NotFound();
                }
                return customers;
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }

        }

        [HttpPost("Customer")]
        public async Task<ActionResult> PostCustomerAsync([FromBody] CustomerViewModel model)
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

        [HttpPut("UpdateCustomer")]
        public async Task<ActionResult> PutCustomerAsync([FromBody] CustomerViewModel model)
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
        [HttpDelete("DeleteCustomers")]
        public async Task<ActionResult> DeleteCustomersAsync()
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