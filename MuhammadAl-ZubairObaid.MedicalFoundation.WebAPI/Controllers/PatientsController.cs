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
        /// <summary>
        /// Initializes new instance of <see cref="PatientsController"/>
        /// </summary>
        /// <param name="repository">Medical foundation repository</param>
        public PatientsController(IMFRepository<Patient> repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Adds <see cref="Patient"/> to MF repository
        /// </summary>
        /// <param name="patient"><see cref="Patient"/> object</param>
        /// <returns>Action result</returns>
        [HttpPut()]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> AddPatient(Patient patient)
        {
            var result = await _repository.Add(patient);
            if (result is true)
                return Ok();
            else
                return BadRequest();
        }
        /// <summary>
        /// Updates <see cref="Patient"/> on MF repository
        /// </summary>
        /// <param name="patient"><see cref="Patient"/> object</param>
        /// <returns>Action result</returns>
        [HttpPost()]
        [Authorize(Policy = "Admin")]
        public IActionResult UpdatePatient(Patient patient)
        {
            var result = _repository.Update(patient);
            if (result is true)
                return Ok();
            else
                return NotFound();
        }
        /// <summary>
        /// Deletes <see cref="Patient"/> from MF repository
        /// </summary>
        /// <param name="patient"><see cref="Patient"/> object</param>
        /// <returns>Action result</returns>
        [HttpDelete()]
        [Authorize(Policy = "Admin")]
        public IActionResult DeletePatient(Patient patient)
        {
            var result = _repository.Remove(patient);
            if (result is true)
                return Ok();
            else
                return NotFound();
        }
        /// <summary>
        /// Retreives <see cref="Patient"/> from MF repository based on entity ID
        /// </summary>
        /// <param name="patientId"><see cref="Patient"/> <see cref="Guid"/></param>
        /// <returns>Action result</returns>
        [HttpGet("/{patientId}")]
        public async Task<IActionResult> GetPatient(Guid patientId)
        {
            var result = await _repository.Get(patientId);
            if (result is not null)
                return Json(result);
            else
                return NotFound();
        }
        /// <summary>
        /// Retreives <see cref="Patient"/>s from MF repository; To handle enormous number of objects, pagenation is required
        /// </summary>
        /// <param name="pageIndex">Page number to start; Starting from 0</param>
        /// <param name="countForEveryPage">Number of objects per page</param>
        /// <returns>Action result</returns>
        [HttpGet("/patientList/{pageIndex}/{countForEveryPage}")]
        public async Task<IActionResult> GetPatients(int pageIndex, int countForEveryPage)
        {
            var result = await _repository.All(pageIndex, countForEveryPage);
            if (result.Count > 0)
                return Json(result);
            else
                return NotFound();
        }

    }
}
