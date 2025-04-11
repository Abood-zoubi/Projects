namespace Biding_management_System.Application.DTOs.TenderEvaluation
{
    public class BidEvaluationDTO
    {
        public int BidingId { get; set; }
        public decimal PriceScore { get; set; }
        public decimal ExperienceScore { get; set; }
        public decimal ComplianceScore { get; set; }
        public decimal TotalScore => PriceScore + ExperienceScore + ComplianceScore;
    }
}
