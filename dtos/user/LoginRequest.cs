namespace zilicoPOSAPI.dtos.User;

public class LoginRequest
{
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public bool IsActive { get; set; }
}