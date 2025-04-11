using Biding_management_System.Application.DTOs.Bid;
using Biding_management_System.Domain.Entities.Bids;

namespace Biding_management_System.Application.Interfaces
{
    public interface IBidService
    {
        Task<Bid> SubmitBidAsync(BidSubmissionDTO bidSubmissionDTO, int userId);
    }
}
