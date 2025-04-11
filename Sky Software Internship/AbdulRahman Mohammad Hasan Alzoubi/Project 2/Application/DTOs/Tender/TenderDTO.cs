namespace Biding_management_System.Application.DTOs.Tender
{
    public class TenderDTO
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime Deadline { get; set; }
        public decimal Budget { get; set; }
        public string EligibilityCriteria { get; set; } = null!;
        public int CategoryId { get; set; }
    }
}
