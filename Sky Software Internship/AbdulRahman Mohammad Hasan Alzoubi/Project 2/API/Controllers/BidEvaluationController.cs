using Biding_management_System.Application.DTOs.TenderEvaluation;
using Biding_management_System.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biding_management_System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidEvaluationController : ControllerBase
    {
        private readonly BidEvaluationService _bidEvaluationService;

        public BidEvaluationController(BidEvaluationService bidEvaluationService)
        {
            _bidEvaluationService = bidEvaluationService;
        }

        [HttpPost("evaluate")]
        public async Task<IActionResult> EvaluateBid([FromBody] BidEvaluationDTO evaluationDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var evaluation = await _bidEvaluationService.EvaluateBidAsync(evaluationDTO);
                return CreatedAtAction(nameof(EvaluateBid), new { id = evaluation.BidEvaluationId }, evaluation);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPost("award/{tenderId}")]
        public async Task<IActionResult> AwardBid(int tenderId)
        {
            try
            {
                var bestBid = await _bidEvaluationService.AwardBidAsync(tenderId);
                if (bestBid == null)
                    return NotFound("No best bid found to award.");

                return Ok(bestBid);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
