using Microsoft.AspNetCore.Mvc;
using FermliAPI.Services;
using FermliAPI.Models;
using System.Collections.Generic;

namespace FermliAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentService _appointmentService;
        public AppointmentController(AppointmentService appServ)
        {
            _appointmentService = appServ;
        }
        [HttpGet]
        public ActionResult<List<Appointment>> Get(string patientId)
        {
            var app = _appointmentService.GetAll(patientId);
            if(app == null)
            {
                return NotFound();
            }
            return app;
        }
        [HttpGet("{id}" ,Name = "GetApp")]
        public ActionResult<Appointment>Get(string id, string patientId)
        {
            var app = _appointmentService.Get(id);
            if (app.patientId == patientId) {
                if (app == null)
                {
                    return NotFound();
                }
            }
            
            return app;
        }
        [HttpPost]
        public ActionResult<Appointment> Create(Appointment app)
        {
            _appointmentService.Create(app);
            return CreatedAtRoute("GetApp", new { id = app.id.ToString() }, app);
        }
        [HttpPut("{id}")]
        public IActionResult Update(string id, Appointment appIn)
        {
            var app = _appointmentService.Get(id);
            if (app == null)
            {
                return NotFound();
            }
            _appointmentService.Update(id, appIn);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id,string patientId)
        {
            var app = _appointmentService.Get(id);
            if (app == null)
            {
                return NotFound();
            }
            else if( patientId == app.patientId )
            {
                _appointmentService.Remove(id);
                return NoContent();
            }
            return NoContent();
        }
    }
}
