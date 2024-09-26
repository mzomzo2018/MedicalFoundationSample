using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuhammadAl_ZubairObaid.MedicalFoundation.Contexts;
using MuhammadAl_ZubairObaid.MedicalFoundation.Data.Repositories;
using MuhammadAl_ZubairObaid.MedicalFoundation.Domain;
using MuhammadAl_ZubairObaid.MedicalFoundation.Domain.Primitives;

namespace MuhammadAl_ZubairObaid.MedicalFoundation.WebAPI.Controllers
{
    /// <summary>
    /// Billing controller, containing CRUD operations on billing data
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class BillingsController : Controller
    {
        private IMFRepository<Billing> _repository;
        /// <summary>
        /// Initializes new instance of <see cref="BillingsController"/>
        /// </summary>
        /// <param name="repository">Medical foundation repository</param>
        public BillingsController(IMFRepository<Billing> repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Adds <see cref="Billing"/> to MF repository
        /// </summary>
        /// <param name="billing"><see cref="Billing"/> object</param>
        /// <returns>Action result</returns>
        [HttpPut]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> AddBilling(Billing billing)
        {
            var result = await _repository.Add(billing);
            if (result is true)
                return Ok();
            else
                return BadRequest();
        }
        /// <summary>
        /// Updates <see cref="Billing"/> on MF repository
        /// </summary>
        /// <param name="billing"><see cref="Billing"/> object</param>
        /// <returns>Action result</returns>
        [HttpPost]
        [Authorize(Policy = "Admin")]
        public IActionResult UpdateBilling(Billing billing)
        {
            var result = _repository.Update(billing);
            if (result is true)
                return Ok();
            else
                return NotFound();
        }
        /// <summary>
        /// Deletes <see cref="Billing"/> from MF repository
        /// </summary>
        /// <param name="billing"><see cref="Billing"/> object</param>
        /// <returns>Action result</returns>
        [HttpDelete]
        [Authorize(Policy = "Admin")]
        public IActionResult DeleteBilling(Billing billing)
        {
            var result = _repository.Remove(billing);
            if (result is true)
                return Ok();
            else
                return NotFound();
        }
        /// <summary>
        /// Retreives <see cref="Billing"/> from MF repository based on entity ID
        /// </summary>
        /// <param name="billingId"><see cref="Billing"/> <see cref="Guid"/></param>
        /// <returns>Action result</returns>
        [HttpGet("/{billingId}")]
        public async Task<IActionResult> GetBilling(Guid billingId)
        {
            var result = await _repository.Get(billingId);
            if (result is not null)
                return Json(result);
            else
                return NotFound();
        }
        /// <summary>
        /// Retreives <see cref="Billing"/>s from MF repository; To handle enormous number of objects, pagenation is required
        /// </summary>
        /// <param name="pageIndex">Page number to start; Starting from 0</param>
        /// <param name="countForEveryPage">Number of objects per page</param>
        /// <returns>Action result</returns>
        [HttpGet]
        public async Task<IActionResult> GetBillings(int pageIndex, int countForEveryPage)
        {
            var result = await _repository.All(pageIndex, countForEveryPage);
            if (result.Count > 0)
                return Json(result);
            else
                return NotFound();
        }
    }
}
