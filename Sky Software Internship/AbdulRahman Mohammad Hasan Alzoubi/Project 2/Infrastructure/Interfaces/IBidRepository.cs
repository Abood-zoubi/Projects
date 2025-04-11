using Biding_management_System.Domain.Entities.Bids;

namespace Biding_management_System.Infrastructure.Interfaces
{
    public interface IBidRepository
    {
        Task<Bid> GetBidByIdAsync(int bidId);
        Task<List<Bid>> GetBidsByTenderIdAsync(int tenderId);
        Task CreateBidAsync(Bid bid);
        Task UpdateBidAsync(Bid bid);
        Task DeleteBidAsync(int bidId);
    }
}
