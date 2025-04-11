using Biding_management_System.Application.DTOs.Bid;
using Biding_management_System.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Biding_management_System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
        private readonly IBidService _bidService;

        public BidController(IBidService bidService)
        {
            _bidService = bidService;
        }

        // POST: api/Bid/submit
        [HttpPost("submit")]
        public async Task<IActionResult> SubmitBid([FromBody] BidSubmissionDTO bidSubmissionDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // Retrieve the user ID from the claims in the JWT token
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                // Call the service to submit the bid using the actual user ID
                var bid = await _bidService.SubmitBidAsync(bidSubmissionDTO, userId);
                return CreatedAtAction(nameof(SubmitBid), new { id = bid.BidId }, bid);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}