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
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentLogic _logic;

        public AppointmentsController(IAppointmentLogic logic)
        {
            _logic = logic;
        }

        [HttpGet("Appointment")]
        public async Task<ActionResult<List<AppointmentViewModel>>> GetAppointmentsAsync()
        {
            try
            {

                var Appointments = await _logic.GetAllAsync();

                if (Appointments == null)
                {
                    return NotFound();
                }
                return Appointments;
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }

        }

        [HttpPost("Appointment")]
        public async Task<ActionResult> PostAppointmentAsync([FromBody] AppointmentViewModel model)
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

        [HttpPut("UpdateAppointment")]
        public async Task<ActionResult> PutAppointmentAsync([FromBody] AppointmentViewModel model)
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
        [HttpDelete("DeleteAppointments")]
        public async Task<ActionResult> DeleteAppointmentsAsync()
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