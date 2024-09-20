using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuhammadAl_ZubairObaid.MedicalFoundation.Contexts;
using MuhammadAl_ZubairObaid.MedicalFoundation.Data.Repositories;
using MuhammadAl_ZubairObaid.MedicalFoundation.Domain;

namespace MuhammadAl_ZubairObaid.MedicalFoundation.WebAPI.Controllers
{
    /// <summary>
    /// Patient controller, containing CRUD operations on patient data
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class PatientsController : Controller
    {
        private IMFRepository<Patient> _repository;

        public PatientsController(IMFRepository<Patient> repository) 
        {
            _repository = repository;
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> AddPatient(Patient patient)
        {
            var result = await _repository.Add(patient);
            if (result is true)
                return Ok();
            else
                return BadRequest();
        }
        [HttpPost]
        [Authorize]
        public IActionResult UpdatePatient(Patient patient)
        {
            var result = _repository.Update(patient);
            if (result is true)
                return Ok();
            else
                return NotFound();
        }
        [HttpDelete]
        [Authorize]
        public IActionResult DeletePatient(Patient patient)
        {
            var result = _repository.Remove(patient);
            if (result is true)
                return Ok();
            else
                return NotFound();
        }     
        [HttpGet("/{patientId}")]
        public async Task<IActionResult> GetPatient(Guid patientId)
        {
            var result = await _repository.Get(patientId);
            if (result is not null)
                return Json(result);
            else
                return NotFound();
        }     
        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            var result = await _repository.All();
            if (result.Count > 0)
                return Json(result);
            else
                return NotFound();
        }
    }
}
