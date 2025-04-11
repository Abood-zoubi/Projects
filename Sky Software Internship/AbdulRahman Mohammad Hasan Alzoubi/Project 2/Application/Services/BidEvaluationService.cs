using Biding_management_System.Application.DTOs.TenderEvaluation;
using Biding_management_System.Domain.Entities.Bids;
using Biding_management_System.Domain.Entities.Enums;
using Biding_management_System.Domain.Entities;
using Biding_management_System.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Biding_management_System.Infrastructure.Interfaces;

namespace Biding_management_System.Application.Services
{
    public class BidEvaluationService
    {
        private readonly IBidEvaluationRepository _bidEvaluationRepository;

        public BidEvaluationService(IBidEvaluationRepository bidEvaluationRepository)
        {
            _bidEvaluationRepository = bidEvaluationRepository;
        }

        public async Task<BidEvaluation> EvaluateBidAsync(BidEvaluationDTO evaluationDTO)
        {
            var totalScore = evaluationDTO.PriceScore + evaluationDTO.ExperienceScore + evaluationDTO.ComplianceScore;

            var evaluation = new BidEvaluation
            {
                BidingId = evaluationDTO.BidingId,
                PriceScore = evaluationDTO.PriceScore,
                ExperienceScore = evaluationDTO.ExperienceScore,
                ComplianceScore = evaluationDTO.ComplianceScore,
                TotalScore = totalScore
            };

            return await _bidEvaluationRepository.AddEvaluationAsync(evaluation);
        }

        public async Task<List<BidEvaluation>> GetEvaluationsAsync()
        {
            return await _bidEvaluationRepository.GetAllEvaluationsAsync();
        }

        public async Task<Bid?> AwardBidAsync(int tenderId)
        {
            var evaluations = await _bidEvaluationRepository.GetAllEvaluationsAsync();

            var bestBid = evaluations
                .Where(e => e.Bid.TenderId == tenderId)
                .OrderByDescending(e => e.TotalScore)      
                .Select(e => e.Bid)                        
                .FirstOrDefault();                         

            if (bestBid != null)
            {
                bestBid.Status = BidStatus.Accepted;
                await _bidEvaluationRepository.SaveChangesAsync();
            }

            return bestBid;
        }
    }
}
