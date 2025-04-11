using Biding_management_System.Domain.Entities.Bids;
using Biding_management_System.Infrastructure.Data;
using Biding_management_System.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Biding_management_System.Infrastructure.Repositories
{
    public class BidRepository : IBidRepository
    {
        private readonly AppDbContext _context;

        public BidRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Bid> GetBidByIdAsync(int bidId)
        {
            return await _context.Bids
                .Include(b => b.Documents)
                .FirstOrDefaultAsync(b => b.BidId == bidId);
        }

        public async Task<List<Bid>> GetBidsByTenderIdAsync(int tenderId)
        {
            return await _context.Bids
                .Where(b => b.TenderId == tenderId)
                .Include(b => b.Documents)
                .ToListAsync();
        }

        public async Task CreateBidAsync(Bid bid)
        {
            await _context.Bids.AddAsync(bid);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBidAsync(Bid bid)
        {
            _context.Bids.Update(bid);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBidAsync(int bidId)
        {
            var bid = await _context.Bids.FindAsync(bidId);
            if (bid != null)
            {
                _context.Bids.Remove(bid);
                await _context.SaveChangesAsync();
            }
        }
    }
}
