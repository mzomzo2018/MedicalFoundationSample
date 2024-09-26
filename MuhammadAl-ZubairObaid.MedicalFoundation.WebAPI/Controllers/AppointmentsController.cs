using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuhammadAl_ZubairObaid.MedicalFoundation.Contexts;
using MuhammadAl_ZubairObaid.MedicalFoundation.Data.Repositories;
using MuhammadAl_ZubairObaid.MedicalFoundation.Domain;

namespace MuhammadAl_ZubairObaid.MedicalFoundation.WebAPI.Controllers
{
    /// <summary>
    /// Clinic appointments controller, containing CRUD operations on clinic appointments data
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class ClinicAppointmentsController : Controller
    {
        private IMFRepository<ClinicAppointment> _repository;

        public ClinicAppointmentsController(IMFRepository<ClinicAppointment> repository)
        {
            _repository = repository;
        }
        [HttpPut]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> AddClinicAppointment(ClinicAppointment clinicAppointment)
        {
            var result = await _repository.Add(clinicAppointment);
            if (result is true)
                return Ok();
            else
                return BadRequest();
        }
        [HttpPost]
        [Authorize(Policy = "Admin")]
        public IActionResult UpdateClinicAppointment(ClinicAppointment clinicAppointment)
        {
            var result = _repository.Update(clinicAppointment);
            if (result is true)
                return Ok();
            else
                return NotFound();
        }
        [HttpDelete]
        [Authorize(Policy = "Admin")]
        public IActionResult DeleteClinicAppointment(ClinicAppointment clinicAppointment)
        {
            var result = _repository.Remove(clinicAppointment);
            if (result is true)
                return Ok();
            else
                return NotFound();
        }     
        [HttpGet("/{clinicAppointmentId}")]
        public async Task<IActionResult> GetClinicAppointment(Guid clinicAppointmentId)
        {
            var result = await _repository.Get(clinicAppointmentId);
            if (result is not null)
                return Json(result);
            else
                return NotFound();
        }    
        [HttpGet]
        public async Task<IActionResult> GetClinicAppointments()
        {
            var result = await _repository.All();
            if (result.Count > 0)
                return Json(result);
            else
                return NotFound();
        }
    }
}
