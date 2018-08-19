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
    public class SchedulesController : Controller
    {
        private readonly IScheduleLogic _logic;

        public SchedulesController(IScheduleLogic logic)
        {
            _logic = logic;
        }

        [HttpGet("Schedule")]
        public async Task<ActionResult<List<ScheduleViewModel>>> GetSchedulesAsync()
        {
            try
            {

                var Schedules = await _logic.GetAllAsync();

                if (Schedules == null)
                {
                    return NotFound();
                }
                return Schedules;
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }

        }

        [HttpPost("Schedule")]
        public async Task<ActionResult> PostScheduleAsync([FromBody] ScheduleViewModel model)
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

        [HttpPut("UpdateSchedule")]
        public async Task<ActionResult> PutScheduleAsync([FromBody] ScheduleViewModel model)
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
        [HttpDelete("DeleteSchedules")]
        public async Task<ActionResult> DeleteSchedulesAsync()
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