using zilicoPOSAPI.Daos.User;
using zilicoPOSAPI.Entities;
using zilicoPOSAPI.Interfaces;

namespace zilicoPOSAPI.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthRepository _authRepository;
    private readonly ITokenService _tokenService; // For JWT or similar tokens

    public AuthService(IUserRepository userRepository, IAuthRepository authRepository, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _authRepository = authRepository;
        _tokenService = tokenService;
    }

    public async Task<string> LoginAsync(string username, string password)
    {
        var login = await _authRepository.AuthenticateUserAsync(username, HashPassword(password));
        if (login == null || !login.IsActive) throw new UnauthorizedAccessException("Invalid credentials or account inactive.");

        // Generate JWT token or session
        var user = await _userRepository.GetByIdAsync(login.UserId);
        return _tokenService.GenerateToken(user.Id, user.GroupId);
    }

    public async Task RegisterAsync(RegisterUserDao registerUserDao)
    {
        if (await _userRepository.CheckUserExistsAsync(registerUserDao.Username))
            throw new InvalidOperationException("User with this email already exists.");

        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = registerUserDao.FirstName,
            LastName = registerUserDao.LastName,
            Email = registerUserDao.Email,
            Phone = registerUserDao.Phone,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _userRepository.AddAsync(user);

        var login = new Login
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            Username = registerUserDao.Username,
            PasswordHash = HashPassword(registerUserDao.Password),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _userRepository.AddLoginAsync(login);
    }

    public async Task<bool> CheckPermissionAsync(Guid userId, string functionalityName)
    {
        var permissions = await _userRepository.GetUserPermissionsAsync(userId);
        return permissions?.Any(p => p.Name == functionalityName) ?? false;
    }

    public async Task ReAuthenticateAsync(Guid userId)
    {
        // Additional checks if re-authentication is needed
        await _authRepository.ReactivateAccessAsync(userId);
    }

    private string HashPassword(string password)
    {
        // Implement a secure password hashing mechanism (e.g., BCrypt or SHA256)
        return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
    }
}
