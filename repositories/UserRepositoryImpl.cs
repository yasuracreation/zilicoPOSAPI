using zilicoPOSAPI.dtos.User;
using zilicoPOSAPI.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Linq;
using zilicoPOSAPI.Mappers;
using Microsoft.EntityFrameworkCore;
using zilicoPOSAPI.Context;
using zilicoPOSAPI.Entities;

namespace zilicoPOSAPI.Repositories
{
    public class UserRepositoryImpl : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UserRepositoryImpl> _logger;

        public UserRepositoryImpl(ApplicationDbContext applicationDbContext, ILogger<UserRepositoryImpl> logger)
        {
            _context = applicationDbContext;
            _logger = logger;
        }
        public async Task<User?> createUser(CreateUserRequest createUserRequest)
        {
            var user = UserMapper.MapCreateUserRequestToUser(createUserRequest);

           return await this.AddAsync(user);
        }

        public async Task<User?> updateUser(int Id, UpdateUserRequest updateUserRequest)
        {
            var user = await _context.Users.FindAsync(Id);
            if (user == null) return null;
            var updateUser = UserMapper.MapUpdateUserRequestToUser(updateUserRequest);
            updateUser.FirstName = updateUserRequest.FirstName;
            updateUser.LastName =updateUserRequest.LastName;
            updateUser.Email = updateUserRequest.Email;
            updateUser.Phone = updateUserRequest.Phone;
            updateUser.UpdatedAt = DateTime.UtcNow;
            return await this.UpdateAsync(updateUser);
        }

        public async Task<User?> deleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;
            return await this.DeleteAsync(user);
        }

        public async Task<bool> CheckUserExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task AddLoginAsync(Login login)
        {
            await _context.Logins.AddAsync(login);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLoginAsync(Login login)
        {
            _context.Logins.Update(login);
            await _context.SaveChangesAsync();
        }

        public async Task<UserGroup> GetUserGroupByUserIdAsync(Guid userId)
        {
            var user = await _context.Users.Include(u => u.Group).FirstOrDefaultAsync(u => u.Id == userId);
            return user.Group;
        }

        public async Task<ICollection<SysFunctionality>> GetUserPermissionsAsync(Guid userId)
        {
            var userGroup = await GetUserGroupByUserIdAsync(userId);
            if (userGroup == null) return null;

            return await _context.RoleGroupFunctionalities
                .Include(rgf => rgf.Functionality)
                .Where(rgf => rgf.RoleGroup.UserGroupId == userGroup.Id.ToString())
                .Select(rgf => rgf.Functionality)
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<User?> GetUserByNameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.FirstName == username);
        }
        public async Task<User> AddAsync(User entity)
        {
          //  var user = UserMapper.MapCreateUserRequestToUser(createUserRequest);

            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<User> UpdateAsync(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<User> DeleteAsync(User entity)
        {
            
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
