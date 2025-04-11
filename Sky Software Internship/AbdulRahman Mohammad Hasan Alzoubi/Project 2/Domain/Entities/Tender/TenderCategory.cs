namespace Biding_management_System.Domain.Entities.Tender
{
    public class TenderCategory
    {
        public int CategoryId { get; set; }
        public string Industry { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Location { get; set; } = null!;
        public List<Tender> Tenders { get; set; } = new();
    }
}
