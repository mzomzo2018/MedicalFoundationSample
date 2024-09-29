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
        /// <summary>
        /// Initializes new instance of <see cref="CliniciansController"/>
        /// </summary>
        /// <param name="repository">Medical foundation repository</param>
        public CliniciansController(IMFRepository<Clinician> repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Adds <see cref="Clinician"/> to MF repository
        /// </summary>
        /// <param name="clinician"><see cref="Clinician"/> object</param>
        /// <returns>Action result</returns>
        [HttpPut()]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> AddClinician(Clinician clinician)
        {
            var result = await _repository.Add(clinician);
            if (result is true)
                return Ok();
            else
                return BadRequest();
        }
        /// <summary>
        /// Updates <see cref="Clinician"/> on MF repository
        /// </summary>
        /// <param name="clinician"><see cref="Clinician"/> object</param>
        /// <returns>Action result</returns>
        [HttpPost()]
        [Authorize(Policy = "Admin")]
        public IActionResult UpdateClinician(Clinician clinician)
        {
            var result = _repository.Update(clinician);
            if (result is true)
                return Ok();
            else
                return NotFound();
        }
        /// <summary>
        /// Deletes <see cref="Clinician"/> from MF repository
        /// </summary>
        /// <param name="clinician"><see cref="Clinician"/> object</param>
        /// <returns>Action result</returns>
        [HttpDelete()]
        [Authorize(Policy = "Admin")]
        public IActionResult DeleteClinician(Clinician clinician)
        {
            var result = _repository.Remove(clinician);
            if (result is true)
                return Ok();
            else
                return NotFound();
        }
        /// <summary>
        /// Retreives <see cref="Clinician"/> from MF repository based on entity ID
        /// </summary>
        /// <param name="clinicianId"><see cref="Clinician"/> <see cref="Guid"/></param>
        /// <returns>Action result</returns>
        [HttpGet("/{clinicianId}")]
        public async Task<IActionResult> GetClinician(Guid clinicianId)
        {
            var result = await _repository.Get(clinicianId);
            if (result is not null)
                return Json(result);
            else
                return NotFound();
        }
        /// <summary>
        /// Retreives <see cref="Clinician"/>s from MF repository; To handle enormous number of objects, pagenation is required
        /// </summary>
        /// <param name="pageIndex">Page number to start; Starting from 0</param>
        /// <param name="countForEveryPage">Number of objects per page</param>
        /// <returns>Action result</returns>
        [HttpGet("/clinicianList/{pageIndex}/{countForEveryPage}")]
        public async Task<IActionResult> GetClinicians(int pageIndex, int countForEveryPage)
        {
            var result = await _repository.All(pageIndex, countForEveryPage);
            if (result.Count > 0)
                return Json(result);
            else
                return NotFound();
        }

    }
}
