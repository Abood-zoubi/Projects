using Biding_management_System.Domain.Entities;

namespace Biding_management_System.Infrastructure.Interfaces
{
    public interface IBidEvaluationRepository
    {
        Task<BidEvaluation> AddEvaluationAsync(BidEvaluation evaluation);
        Task<List<BidEvaluation>> GetAllEvaluationsAsync();
        Task<BidEvaluation> GetEvaluationByIdAsync(int evaluationId);
        Task SaveChangesAsync();
    }
}
