using zilicoPOSAPI.Entities;

namespace zilicoPOSAPI.Interfaces;

public interface IAuthRepository
{
    Task<Login> AuthenticateUserAsync(string username, string passwordHash);
    Task<bool> VerifyPasswordAsync(Guid userId, string passwordHash);
    Task UpdatePasswordAsync(Guid userId, string newPasswordHash);
    Task RevokeAccessAsync(Guid userId); // Disable login temporarily
    Task ReactivateAccessAsync(Guid userId); // Re-enable login
}