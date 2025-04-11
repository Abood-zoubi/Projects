using Biding_management_System.Application.DTOs.TenderEvaluation;
using Biding_management_System.Domain.Entities.Bids;
using Biding_management_System.Domain.Entities;

namespace Biding_management_System.Application.Interfaces
{
    public interface IBidEvaluationService
    {
        Task<BidEvaluation> EvaluateBidAsync(BidEvaluationDTO evaluationDTO);
        Task<List<BidEvaluation>> GetEvaluationsAsync();
        Task<Bid?> AwardBidAsync(int tenderId);
    }
}
