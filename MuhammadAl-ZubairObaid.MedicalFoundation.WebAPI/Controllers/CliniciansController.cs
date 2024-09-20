using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuhammadAl_ZubairObaid.MedicalFoundation.Contexts;
using MuhammadAl_ZubairObaid.MedicalFoundation.Data.Repositories;
using MuhammadAl_ZubairObaid.MedicalFoundation.Domain;

namespace MuhammadAl_ZubairObaid.MedicalFoundation.WebAPI.Controllers
{
    /// <summary>
    /// Clinician controller, containing CRUD operations on clinician data
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class CliniciansController : Controller
    {
        private IMFRepository<Clinician> _repository;

        public CliniciansController(IMFRepository<Clinician> repository)
        {
            _repository = repository;
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> AddClinician(Clinician clinician)
        {
            var result = await _repository.Add(clinician);
            if (result is true)
                return Ok(clinician);
            else
                return BadRequest();
        }
        [HttpPost]
        [Authorize]
        public IActionResult UpdateClinician(Clinician clinician)
        {
            var result = _repository.Update(clinician);
            if (result is true)
                return Ok(clinician);
            else
                return NotFound();
        }
        [HttpDelete]
        [Authorize]
        public IActionResult DeleteClinician(Clinician clinician)
        {
            var result = _repository.Remove(clinician);
            if (result is true)
                return Ok(clinician);
            else
                return NotFound();
        }     
        [HttpGet("/{clinicianID}")]
        public async Task<IActionResult> GetClinician(Guid clinicianId)
        {
            var result = await _repository.Get(clinicianId);
            if (result is not null)
                return Ok(result);
            else
                return NotFound();
        }     
        [HttpGet]
        public async Task<IActionResult> GetClinicians()
        {
            var result = await _repository.All();
            if (result.Count > 0)
                return Ok(result);
            else
                return NotFound();
        }
    }
}
