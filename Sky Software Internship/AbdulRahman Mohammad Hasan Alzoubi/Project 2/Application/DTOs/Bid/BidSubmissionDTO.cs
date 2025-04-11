using System.ComponentModel.DataAnnotations;

namespace Biding_management_System.Application.DTOs.Bid
{
    public class BidSubmissionDTO
    {
        [Required]
        public int TenderId { get; set; }
        [Required]
        public decimal BidAmount { get; set; }
        public List<IFormFile> Documents { get; set; } = new(); 
    }
}
