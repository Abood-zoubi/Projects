using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Biding_management_System.Domain.Entities.Bids
{
    public class BidDocument
    {
        [Key]
        public int DocumentId { get; set; }

        [Required]
        public string FileName { get; set; } = null!;

        [Required]
        public string FilePath { get; set; } = null!; 

        [Required]
        public int BidId { get; set; }

        [ForeignKey(nameof(BidId))]
        public Bid Bid { get; set; } = null!;
    }
}
