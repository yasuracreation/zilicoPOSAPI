namespace zilicoPOSAPI.dtos.User;

public class RegisterUserRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
        
    public string Password { get; set; } // Consider hashing this before saving
    public string GroupId { get; set; } // Assuming this is used for user grouping
}