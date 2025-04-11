using Biding_management_System.Application.DTOs.Bid;
using Biding_management_System.Application.Interfaces;
using Biding_management_System.Domain.Entities.Bids;
using Biding_management_System.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Biding_management_System.Application.Services
{
    public class BidService : IBidService
    {
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;

        public BidService(AppDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public async Task<Bid> SubmitBidAsync(BidSubmissionDTO bidSubmissionDTO, int userId)
        {
            var tender = await _context.Tenders
                .Include(t => t.Bids)
                .FirstOrDefaultAsync(t => t.TenderId == bidSubmissionDTO.TenderId);

            if (tender == null) throw new Exception("Tender not found.");

            var bid = new Bid
            {
                TenderId = bidSubmissionDTO.TenderId,
                Tender = tender,
                BidAmount = bidSubmissionDTO.BidAmount,
                BidderId = userId
            };

            tender.Bids.Add(bid);

            if (bidSubmissionDTO.Documents.Any())
            {
                foreach (var file in bidSubmissionDTO.Documents)
                {
                    var filePath = Path.Combine("wwwroot", "uploads", "bids", Guid.NewGuid().ToString() + Path.GetExtension(file.FileName));
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    bid.Documents.Add(new BidDocument
                    {
                        FileName = file.FileName,
                        FilePath = filePath,
                    });
                }
            }

            await _context.Bids.AddAsync(bid);
            await _context.SaveChangesAsync();

            return bid;
        }
    }
}
