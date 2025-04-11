namespace Biding_management_System.Application.DTOs.Tender
{
    public class UpdateTenderDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? Deadline { get; set; }
        public decimal? Budget { get; set; }
        public List<IFormFile>? Document { get; set; }
    }
}
