namespace FleetManagement.Models
{
    public class Document
    {
        public Guid DocumentId { get; set; }
        public Guid EntityId { get; set; } 
        public string DocumentType { get; set; }
        public string DocumentPath { get; set; }
        public DateTime UploadedAt { get; set; }

    }
}
