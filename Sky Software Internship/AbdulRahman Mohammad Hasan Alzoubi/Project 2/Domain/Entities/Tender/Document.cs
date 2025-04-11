using System.ComponentModel.DataAnnotations;

namespace Biding_management_System.Domain.Entities.Tender
{
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }
        public string FileName { get; set; } = null!;
        public string FilePath { get; set; } = null!;
        public int TenderId { get; set; }
        public Tender Tender { get; set; } = null!;
    }
}
