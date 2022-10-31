using Microsoft.AspNetCore.Mvc;
using FermliAPI.Services;
using FermliAPI.Models;
using System.Collections.Generic;
namespace FermliAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly MedicinesService _medicinesService;
        public MedicineController(MedicinesService medicinesService)
        {
            _medicinesService = medicinesService;
        }
        [HttpGet]
        public ActionResult<List<Medicine>> Get() => _medicinesService.Get();
        [HttpGet("{id:length(24)}",Name ="GetMedicine")]
        public ActionResult<Medicine> Get(string id)
        {
            var med = _medicinesService.Get(id);
            if (med == null)
            {
                return NotFound();
            }
            return med;
        }
        [HttpPost]
        public ActionResult<Medicine> Create(Medicine med)
        {
            _medicinesService.Create(med);
            return CreatedAtRoute("GetMedicine", new { id = med.id.ToString() }, med);
        }
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Medicine medIn)
        {
            var med = _medicinesService.Get(id);
            if(med == null)
            {
                return NotFound();
            }
            _medicinesService.Update(id, medIn);
            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var med = _medicinesService.Get(id);
            if(med == null)
            {
                return NotFound();
            }
            _medicinesService.Remove(id);
            return NoContent();
        }
    }
}
