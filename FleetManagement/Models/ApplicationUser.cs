using Microsoft.AspNetCore.Identity;
namespace FleetManagement.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Guid? FleetAccountId { get; set; }
        //public ICollection<Document> Documents { get; set; }
        public FleetAccount FleetAccount { get; set; }

    }
}
