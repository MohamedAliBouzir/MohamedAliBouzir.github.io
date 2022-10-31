using Microsoft.AspNetCore.Mvc;
using FermliAPI.Services;
using FermliAPI.Models;
using System.Collections.Generic;

namespace FermliAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorsService _doctorsService;
        public DoctorController(DoctorsService doctorsService)
        {
            _doctorsService = doctorsService;
        }
        [HttpGet]
        public ActionResult<List<Doctors>> Get() => _doctorsService.Get();
        [HttpGet("{id:length(24)}",Name = "GetDoctor")]
        public ActionResult<Doctors> Get(string id)
        {
            var doc = _doctorsService.Get(id);
            if (doc == null)
            {
                return NotFound();
            }
            return doc;
        }
        [HttpPost]
        public ActionResult<Doctors> Create(Doctors doc)
        {
            _doctorsService.Create(doc);
            return CreatedAtRoute("GetDoctor", new { id = doc.id.ToString() }, doc);
        }
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Doctors docIn)
        {
            var doc = _doctorsService.Get(id);
            if(doc == null)
            {
                return NotFound();
            }
            _doctorsService.Update(id, docIn);
            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var doc = _doctorsService.Get(id);
            if(doc == null)
            {
                return NotFound();
            }
            _doctorsService.Remove(id);
            return NoContent();
        }
    }
}
