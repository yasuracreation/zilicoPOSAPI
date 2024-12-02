using System.ComponentModel.DataAnnotations;

namespace zilicoPOSAPI.dtos.User
{
    public class UpdateUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        // Password is optional for updates; consider whether to allow updating passwords
        public string? Password { get; set; } // Nullable if not updating
    }
    
}
