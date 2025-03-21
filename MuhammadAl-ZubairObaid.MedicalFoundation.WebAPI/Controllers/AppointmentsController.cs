﻿using Microsoft.AspNetCore.Authorization;
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
        /// <summary>
        /// Initializes new instance of <see cref="ClinicAppointmentsController"/>
        /// </summary>
        /// <param name="repository">Medical foundation repository</param>
        public ClinicAppointmentsController(IMFRepository<ClinicAppointment> repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Adds <see cref="ClinicAppointment"/> to MF repository
        /// </summary>
        /// <param name="clinicAppointment"><see cref="ClinicAppointment"/> object</param>
        /// <returns>Action result</returns>
        [HttpPut()]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> AddClinicAppointment(ClinicAppointment clinicAppointment)
        {
            var result = await _repository.Add(clinicAppointment);
            if (result is true)
                return Ok();
            else
                return BadRequest();
        }
        /// <summary>
        /// Updates <see cref="ClinicAppointment"/> on MF repository
        /// </summary>
        /// <param name="clinicAppointment"><see cref="ClinicAppointment"/> object</param>
        /// <returns>Action result</returns>
        [HttpPost()]
        [Authorize(Policy = "Admin")]
        public IActionResult UpdateClinicAppointment(ClinicAppointment clinicAppointment)
        {
            var result = _repository.Update(clinicAppointment);
            if (result is true)
                return Ok();
            else
                return NotFound();
        }
        /// <summary>
        /// Deletes <see cref="ClinicAppointment"/> from MF repository
        /// </summary>
        /// <param name="clinicAppointment"><see cref="ClinicAppointment"/> object</param>
        /// <returns>Action result</returns>
        [HttpDelete()]
        [Authorize(Policy = "Admin")]
        public IActionResult DeleteClinicAppointment(ClinicAppointment clinicAppointment)
        {
            var result = _repository.Remove(clinicAppointment);
            if (result is true)
                return Ok();
            else
                return NotFound();
        }
        /// <summary>
        /// Retreives <see cref="ClinicAppointment"/> from MF repository based on entity ID
        /// </summary>
        /// <param name="clinicAppointmentId"><see cref="ClinicAppointment"/> <see cref="Guid"/></param>
        /// <returns>Action result</returns>
        [HttpGet("/{clinicAppointmentId}")]
        public async Task<IActionResult> GetClinicAppointment(Guid clinicAppointmentId)
        {
            var result = await _repository.Get(clinicAppointmentId);
            if (result is not null)
                return Json(result);
            else
                return NotFound();
        }
        /// <summary>
        /// Retreives <see cref="ClinicAppointment"/>s from MF repository; To handle enormous number of objects, pagenation is required
        /// </summary>
        /// <param name="pageIndex">Page number to start; Starting from 0</param>
        /// <param name="countForEveryPage">Number of objects per page</param>
        /// <returns>Action result</returns>
        [HttpGet("/appointmentList/{pageIndex}/{countForEveryPage}")]
        public async Task<IActionResult> GetClinicAppointments(int pageIndex, int countForEveryPage)
        {
            var result = await _repository.All(pageIndex, countForEveryPage);
            if (result.Count > 0)
                return Json(result);
            else
                return NotFound();
        }
    }
}
