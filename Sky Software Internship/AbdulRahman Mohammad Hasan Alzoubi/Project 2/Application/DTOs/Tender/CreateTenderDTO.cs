using System.ComponentModel.DataAnnotations;

namespace Biding_management_System.Application.DTOs.Tender
{
    public class CreateTenderDTO
    {
        [Required, MaxLength(200)]
        public string Title { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public DateTime Deadline { get; set; }
        [Required]
        public decimal Budget { get; set; }
        public List<IFormFile>? Document { get; set; }
    }
}
