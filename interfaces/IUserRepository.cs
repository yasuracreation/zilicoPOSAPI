using zilicoPOSAPI.dtos.User;
using zilicoPOSAPI.Entities;

namespace zilicoPOSAPI.Interfaces
{
    public interface IUserRepository:IGenericRepository<User>
    {
   
        Task<User?> GetUserByNameAsync(string username);
        Task<User?> createUser(CreateUserRequest createUserRequest);
        Task<User?> updateUser(int Id, UpdateUserRequest updateUserRequest);
        Task<User?> deleteUser(int id);
        Task<bool> CheckUserExistsAsync(string email);
        Task AddLoginAsync(Login login);
        Task UpdateLoginAsync(Login login);
        Task<UserGroup> GetUserGroupByUserIdAsync(Guid userId);
        Task<ICollection<SysFunctionality>> GetUserPermissionsAsync(Guid userId);
    }
}
