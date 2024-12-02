using Microsoft.Identity.Client;
using zilicoPOSAPI.dtos.User;
using zilicoPOSAPI.Entities;
using zilicoPOSAPI.Interfaces;

namespace zilicoPOSAPI.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return (List<User>)await _userRepository.GetAllAsync();
    }

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        return await _userRepository.GetUserByNameAsync(username);
    }

    public async Task<User?> CreateUserAsync(CreateUserRequest createUserRequest)
    {
        return await _userRepository.createUser(createUserRequest);
    }

    public async Task<User?> UpdateUserAsync(int id, UpdateUserRequest updateUserRequest)
    {
        return await _userRepository.updateUser(id, updateUserRequest);
    }

    public async Task<User> DeleteUserAsync(int id)
    {
        return await _userRepository.deleteUser(id);
    }
}