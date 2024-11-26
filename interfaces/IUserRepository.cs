using zilicoPOSAPI.dtos.User;
using zilicoPOSAPI.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace zilicoPOSAPI.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersAsync();
        Task<User?> GetUserAsync(int id);
        Task<User?> GetUserAsync(string username);
        Task<User?> createUser(CreateUserRequest createUserRequest);
        Task<User?> updateUser(int Id, UpdateUserRequest updateUserRequest);
        Task<User?> deleteUser(int id);
    }
}
