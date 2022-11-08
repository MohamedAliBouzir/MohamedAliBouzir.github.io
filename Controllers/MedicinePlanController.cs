using FermliAPI.Models;
using FermliAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FermliAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinePlanController : ControllerBase
    {
        private readonly MedicinePlanService _medPlanService;
        public MedicinePlanController(MedicinePlanService medicinePlanService)
        {
            _medPlanService = medicinePlanService;
        }
        [HttpGet]
        public ActionResult<List<MedicinePlan>> Get(string patientId)
        {
            var medPlan = _medPlanService.GetAll(patientId);
            if(medPlan== null)
            {
                return NotFound();
            }
            return medPlan;
        }
        [HttpGet("{id}",Name ="GetPlan")]
        public ActionResult<MedicinePlan>Get(string id,string patientId)
        {
            var medPlan = _medPlanService.Get(id);
            if (medPlan.patientId == patientId)
            {
                if (medPlan == null)
                {
                    return NotFound();
                }
            }
            return medPlan;
        }
        [HttpPost]
        public ActionResult<MedicinePlan>Create(MedicinePlan medPlan)
        {
            _medPlanService.Create(medPlan);
            return CreatedAtRoute("GetPlan", new { id = medPlan.id.ToString() }, medPlan);
        }
        [HttpPut("{id}")]
        public IActionResult Update(string id,MedicinePlan medPlanIn)
        {
            var medPlan = _medPlanService.Get(id);
            if(medPlan == null)
            {
                return NotFound();
            }
            _medPlanService.Update(id, medPlanIn);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id, string patientId)
        {
            var medPlan = _medPlanService.Get(id);
            if(medPlan == null)
            {
                return NotFound();
            }
            else if ( patientId == medPlan.patientId)
            {
                _medPlanService.Remove(id);
                return NoContent();
            }
            return NoContent();
        }
    }
}
