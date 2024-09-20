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

        public BillingsController(IMFRepository<Billing> repository)
        {
            _repository = repository;
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> AddBilling(Billing billing)
        {
            var result = await _repository.Add(billing);
            if (result is true)
                return Ok();
            else
                return BadRequest();
        }
        [HttpPost]
        [Authorize]
        public IActionResult UpdateBilling(Billing billing)
        {
            var result = _repository.Update(billing);
            if (result is true)
                return Ok();
            else
                return NotFound();
        }
        [HttpDelete]
        [Authorize]
        public IActionResult DeleteBilling(Billing billing)
        {
            var result = _repository.Remove(billing);
            if (result is true)
                return Ok();
            else
                return NotFound();
        }     
        [HttpGet("/{billingId}")]
        public async Task<IActionResult> GetBilling(Guid billingId)
        {
            var result = await _repository.Get(billingId);
            if (result is not null)
                return Json(result);
            else
                return NotFound();
        }    
        [HttpGet]
        public async Task<IActionResult> GetBillings()
        {
            var result = await _repository.All();
            if (result.Count > 0)
                return Json(result);
            else
                return NotFound();
        }
    }
}
