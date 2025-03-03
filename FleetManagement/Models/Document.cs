namespace FleetManagement.Models
{
    public class Document
    {
        public Guid DocumentId { get; set; }
        public Guid OwnerId { get; set; }
        public string OwnerType { get; set; }
        public string DocumentType { get; set; }
        public string DocumeentName { get; set; }
        public string DocumentPath { get; set; }
        public DateTime UploadedAt { get; set; }
        public Guid? UploadedBy { get; set; }

    }
}
