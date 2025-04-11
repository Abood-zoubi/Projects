using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Biding_management_System.Domain.Entities.Tender;
using System.Net.NetworkInformation;
using Biding_management_System.Domain.Entities.Enums;

namespace Biding_management_System.Domain.Entities.Bids
{
    public class Bid
    {
        [Key]
        public int BidId { get; set; }

        [Required]
        public int TenderId { get; set; } 
        [Required]
        public int BidderId { get; set; } 

        [Required]
        public decimal BidAmount { get; set; } 

        public List<BidDocument> Documents { get; set; } = new();
        public BidEvaluation? Evaluation { get; set; }
        public BidStatus Status { get; set; } = BidStatus.Pending;
        [ForeignKey(nameof(TenderId))]
        public required Biding_management_System.Domain.Entities.Tender.Tender Tender { get; set; }
    }
}
