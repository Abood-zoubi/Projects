using Biding_management_System.Domain.Entities.Bids;

namespace Biding_management_System.Domain.Entities
{
    public class BidEvaluation
    {
        public int BidEvaluationId { get; set; }
        public int BidingId { get; set; }
        public decimal PriceScore { get; set; }
        public decimal ExperienceScore { get; set; }
        public decimal ComplianceScore { get; set; }
        public decimal TotalScore { get; set; }
        public Bid Bid { get; set; }
    }
}
