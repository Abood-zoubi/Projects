using Biding_management_System.Application.DTOs.Tender;
using Biding_management_System.Application.Interfaces;
using Biding_management_System.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biding_management_System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        private readonly ITenderService _tenderService;

        public TenderController(ITenderService tenderService)
        {
            _tenderService = tenderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tenders = await _tenderService.GetAllTendersAsync();
            return Ok(tenders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tender = await _tenderService.GetTenderByIdAsync(id);
            if (tender == null) return NotFound("Tender not found");
            return Ok(tender);
        }

        [HttpPost]
        [Authorize(Roles = "Procurement Officer")] // Role-based access
        public async Task<IActionResult> Create([FromBody] CreateTenderDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _tenderService.AddTenderAsync(dto);

            return Ok("Tender created successfully");
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Procurement Officer")] // Only Hiring Manager can update tenders
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTenderDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var success = await _tenderService.UpdateTenderAsync(id, dto);
            if (!success) return NotFound("Tender not found");

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Procurement Officer")] 
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _tenderService.DeleteTenderAsync(id);
            if (!success) return NotFound("Tender not found");

            return NoContent();
        }
    }
}
