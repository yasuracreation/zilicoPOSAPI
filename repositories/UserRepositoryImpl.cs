using zilicoPOSAPI.DataAccess;
using zilicoPOSAPI.dtos.User;
using zilicoPOSAPI.Interfaces;
using zilicoPOSAPI.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Linq;
using zilicoPOSAPI.Mappers;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<User>> GetUsersAsync()
        {
            try
            {
                _logger.LogInformation("Retrieving all users from the database.");
                return await _context.Users
                    .Include(u => u.UserGroup)
                    .Include(u => u.RoleGroup)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving users.");
                throw;
            }
        }

        public async Task<User?> GetUserAsync(int id)
        {
            try
            {
                _logger.LogInformation("Retrieving user with ID {UserId}.", id);
                var user = await _context.Users
                    .Include(u => u.UserGroup)
                    .Include(u => u.RoleGroup)
                    .FirstOrDefaultAsync(u => u.Id == id);

                if (user == null)
                {
                    _logger.LogWarning("User with ID {UserId} was not found.", id);
                }
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving user with ID {UserId}.", id);
                throw;
            }
        }

        public async Task<User?> GetUserAsync(string username)
        {
            try
            {
                _logger.LogInformation("Retrieving user with username {Username}.", username);
                var user = await _context.Users
                    .Include(u => u.UserGroup)
                    .Include(u => u.RoleGroup)
                    .FirstOrDefaultAsync(u => u.Name == username);

                if (user == null)
                {
                    _logger.LogWarning("User with username {Username} was not found.", username);
                }
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving user with username {Username}.", username);
                throw;
            }
        }

        public async Task<User?> createUser(CreateUserRequest createUserRequest)
        {
            try
            {
                _logger.LogInformation("Creating a new user with email {Email}.", createUserRequest.Email);

                var user = UserMapper.MapCreateUserRequestToUser(createUserRequest);

                if (createUserRequest.RoleGroupId.HasValue)
                {
                    var roleGroup = await _context.RoleGroups.FindAsync(createUserRequest.RoleGroupId.Value);
                    if (roleGroup != null)
                    {
                        user.RoleGroup = roleGroup;
                        _logger.LogInformation("Assigned RoleGroup with ID {RoleGroupId} to the new user.", createUserRequest.RoleGroupId.Value);
                    }
                    else
                    {
                        _logger.LogWarning("RoleGroup with ID {RoleGroupId} was not found.", createUserRequest.RoleGroupId.Value);
                    }
                }

                if (createUserRequest.UserGroupId.HasValue)
                {
                    var userGroup = await _context.UserGroups.FindAsync(createUserRequest.UserGroupId.Value);
                    if (userGroup != null)
                    {
                        user.UserGroup = userGroup;
                        _logger.LogInformation("Assigned UserGroup with ID {UserGroupId} to the new user.", createUserRequest.UserGroupId.Value);
                    }
                    else
                    {
                        _logger.LogWarning("UserGroup with ID {UserGroupId} was not found.", createUserRequest.UserGroupId.Value);
                    }
                }

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                _logger.LogInformation("User with email {Email} successfully created.", createUserRequest.Email);

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a user with email {Email}.", createUserRequest.Email);
                throw;
            }
        }

        public async Task<User?> updateUser(int id, UpdateUserRequest updateUserRequest)
        {
            try
            {
                _logger.LogInformation("Updating user with ID {UserId}.", id);
                var user = await _context.Users
                    .Include(u => u.UserGroup)
                    .Include(u => u.RoleGroup)
                    .FirstOrDefaultAsync(u => u.Id == id);

                if (user == null)
                {
                    _logger.LogWarning("User with ID {UserId} was not found.", id);
                    return null;
                }

                // Update properties
                user.Name = updateUserRequest.Name;
                user.Email = updateUserRequest.Email;
                user.Password = updateUserRequest.Password;
                user.UserType = updateUserRequest.UserType;

                // Update RoleGroup if provided
                if (updateUserRequest.RoleGroupId.HasValue)
                {
                    var roleGroup = await _context.RoleGroups.FindAsync(updateUserRequest.RoleGroupId.Value);
                    if (roleGroup != null)
                    {
                        user.RoleGroup = roleGroup;
                        _logger.LogInformation("Updated RoleGroup with ID {RoleGroupId} for user ID {UserId}.", updateUserRequest.RoleGroupId.Value, id);
                    }
                    else
                    {
                        _logger.LogWarning("RoleGroup with ID {RoleGroupId} was not found.", updateUserRequest.RoleGroupId.Value);
                    }
                }

                // Update UserGroup if provided
                if (updateUserRequest.UserGroupId.HasValue)
                {
                    var userGroup = await _context.UserGroups.FindAsync(updateUserRequest.UserGroupId.Value);
                    if (userGroup != null)
                    {
                        user.UserGroup = userGroup;
                        _logger.LogInformation("Updated UserGroup with ID {UserGroupId} for user ID {UserId}.", updateUserRequest.UserGroupId.Value, id);
                    }
                    else
                    {
                        _logger.LogWarning("UserGroup with ID {UserGroupId} was not found.", updateUserRequest.UserGroupId.Value);
                    }
                }

                // Save changes
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                _logger.LogInformation("User with ID {UserId} successfully updated.", id);

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating user with ID {UserId}.", id);
                throw;
            }
        }


        public async Task<User?> deleteUser(int id)
        {
            try
            {
                _logger.LogInformation("Deleting user with ID {UserId}.", id);
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    _logger.LogWarning("User with ID {UserId} was not found.", id);
                    return null;
                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                _logger.LogInformation("User with ID {UserId} successfully deleted.", id);

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting user with ID {UserId}.", id);
                throw;
            }
        }
    }
}
