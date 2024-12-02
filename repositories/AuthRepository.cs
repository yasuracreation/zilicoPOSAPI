using Microsoft.EntityFrameworkCore;
using zilicoPOSAPI.Context;
using zilicoPOSAPI.Entities;
using zilicoPOSAPI.Interfaces;

namespace zilicoPOSAPI.Repositories;

public class AuthRepository : IAuthRepository
{
   
    private readonly ApplicationDbContext _context;
    private readonly ILogger<UserRepositoryImpl> _logger;

    public AuthRepository(ApplicationDbContext applicationDbContext, ILogger<UserRepositoryImpl> logger)
    {
        _context = applicationDbContext;
        _logger = logger;
    }
    public AuthRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Login> AuthenticateUserAsync(string username, string passwordHash)
    {
        return await _context.Logins
            .FirstOrDefaultAsync(login => login.Username == username && login.PasswordHash == passwordHash && login.IsActive);
    }

    public async Task<bool> VerifyPasswordAsync(Guid userId, string passwordHash)
    {
        var login = await _context.Logins.FirstOrDefaultAsync(l => l.UserId == userId);
        if (login == null) return false;

        return login.PasswordHash == passwordHash;
    }

    public async Task UpdatePasswordAsync(Guid userId, string newPasswordHash)
    {
        var login = await _context.Logins.FirstOrDefaultAsync(l => l.UserId == userId);
        if (login == null) throw new InvalidOperationException("User not found.");

        login.PasswordHash = newPasswordHash;
        login.UpdatedAt = DateTime.UtcNow;

        _context.Logins.Update(login);
        await _context.SaveChangesAsync();
    }

    public async Task RevokeAccessAsync(Guid userId)
    {
        var login = await _context.Logins.FirstOrDefaultAsync(l => l.UserId == userId);
        if (login == null) throw new InvalidOperationException("User not found.");

        login.IsActive = false;
        login.UpdatedAt = DateTime.UtcNow;

        _context.Logins.Update(login);
        await _context.SaveChangesAsync();
    }

    public async Task ReactivateAccessAsync(Guid userId)
    {
        var login = await _context.Logins.FirstOrDefaultAsync(l => l.UserId == userId);
        if (login == null) throw new InvalidOperationException("User not found.");

        login.IsActive = true;
        login.UpdatedAt = DateTime.UtcNow;

        _context.Logins.Update(login);
        await _context.SaveChangesAsync();
    }
}
