using zilicoPOSAPI.Daos.User;

namespace zilicoPOSAPI.Interfaces;

public interface IAuthService
{
    public Task<string> LoginAsync(string username, string password);
    public Task RegisterAsync(RegisterUserDao registerUserDao);
    public Task ReAuthenticateAsync(Guid userId);
}