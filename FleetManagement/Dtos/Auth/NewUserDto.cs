using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Dtos.Auth
{
    public class NewUserDto
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "Firstname Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lastname Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter the Email")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter the mobile number")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Enter 10 digit number")]
        public string MobileNo { get; set; }

        public string? FleetAccountId { get; set; }
    }
}
