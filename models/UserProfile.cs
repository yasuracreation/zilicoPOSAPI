using System.ComponentModel.DataAnnotations.Schema;

namespace zilicoPOSAPI.Models
{
    [Table("UsersProfile")]
    public class UserProfile
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string ProfilePictureLocation { get; set; } = string.Empty;

        // Navigation property for User
        public virtual User User { get; set; }
    }
}
