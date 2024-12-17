namespace FleetManagement.Models
{
    public class LoginLog
    {
        public Guid LoginLogId { get; set; } // Primary Key
        public Guid UserId { get; set; } // Foreign Key to User
        public DateTime LoginTime { get; set; }
        public string IPAddress { get; set; }
        public string BrowserInfo { get; set; }

        // Navigational Properties
        public ApplicationUser User { get; set; }
    }
}
