namespace zilicoPOSAPI.Interfaces;

public interface ITokenService
{
    string GenerateToken(Guid userId, Guid userGroupId);
    Guid ValidateToken(string token);
}
