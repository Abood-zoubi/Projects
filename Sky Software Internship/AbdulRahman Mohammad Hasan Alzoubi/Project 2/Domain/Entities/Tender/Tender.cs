using System.ComponentModel.DataAnnotations;
using Biding_management_System.Domain.Entities.Bids;

namespace Biding_management_System.Domain.Entities.Tender
{
    public class Tender
    {
        [Key]
        public int TenderId { get; set; }
        [Required, MaxLength(200)]
        public string Title { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        public DateTime Deadline { get; set; }
        public decimal Budget { get; set; }
        [Required]
        public string EligibilityCriteria { get; set; } = null!;
        public int CategoryId { get; set; }
        public TenderCategory Category { get; set; } = null!;

        public List<Document> Documents { get; set; } = new();
        public List<Bid> Bids { get; set; } = new();
    }
}
