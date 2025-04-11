using Biding_management_System.Domain.Entities;
using Biding_management_System.Infrastructure.Data;
using Biding_management_System.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Biding_management_System.Infrastructure.Repositories
{
    public class BidEvaluationRepository : IBidEvaluationRepository
    {
        private readonly AppDbContext _context;

        public BidEvaluationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BidEvaluation> AddEvaluationAsync(BidEvaluation evaluation)
        {
            _context.BidEvaluations.Add(evaluation);
            await _context.SaveChangesAsync();
            return evaluation;
        }

        public async Task<List<BidEvaluation>> GetAllEvaluationsAsync()
        {
            return await _context.BidEvaluations.Include(e => e.Bid).ToListAsync();
        }

        public async Task<BidEvaluation> GetEvaluationByIdAsync(int evaluationId)
        {
            return await _context.BidEvaluations.Include(e => e.Bid)
                .FirstOrDefaultAsync(e => e.BidEvaluationId == evaluationId);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
