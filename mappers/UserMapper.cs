using Microsoft.AspNetCore.Identity.Data;
using zilicoPOSAPI.Daos.User;
using zilicoPOSAPI.dtos.User;
using zilicoPOSAPI.Entities;
namespace zilicoPOSAPI.Mappers
{
    public static class UserMapper
    {
        public static UserResponse MapUserToUserResponseDto(User user)
        {
            return new UserResponse
            {
                Id = user.Id.ToString(),
                Email = user.Email,
                Name = user.FirstName + " " + user.LastName,
                Phone = user.Phone

            };
        }
        
        public static User MapCreateUserRequestToUser (CreateUserRequest createUserRequest)
        {
            return new User
            {
               
                FirstName = createUserRequest.FirstName, // Ensure matching property names
                LastName = createUserRequest.LastName, // Assuming LastName is part of the request
                Email = createUserRequest.Email,
                Phone = createUserRequest.Phone, // Assuming Phone is part of the request
                GroupId = createUserRequest.GroupId, // Assuming GroupId is part of the request
                CreatedAt = DateTime.UtcNow, // Set creation date
                UpdatedAt = DateTime.UtcNow, // Set updated date
                // Password should be handled securely, consider hashing before saving
                // Password = createUser Request.Password, 
            };
        }
        
        public static User MapUpdateUserRequestToUser (UpdateUserRequest updateUserRequest)
        {
            return new User
            {
                // Assuming Id is passed in the UpdateUser Request
                // Id = updateUser Request.Id, // Uncomment if you want to include Id in the update
                FirstName = updateUserRequest.FirstName, // Ensure matching property names
                LastName = updateUserRequest.LastName, // Assuming LastName is part of the request
                Email = updateUserRequest.Email,
                Phone = updateUserRequest.Phone, // Assuming Phone is part of the request
                // Password should be handled securely, consider hashing before saving
                // Password = updateUser Request.Password, 
                UpdatedAt = DateTime.UtcNow // Update the timestamp
            };
        }

        public static RegisterUserDao MapLoginUserDtoToRegisterUserDao(RegisterUserRequest request)
        {
            return new RegisterUserDao
            {
                FirstName = request.FirstName, // Ensure matching property names
                LastName = request.LastName, // Assuming LastName is part of the request
                Email = request.Email,
                Phone = request.Phone, // Assuming Phone is part of the request
                Password = request.Password,
                GroupId =  Guid.Parse(request.GroupId), 
            };
        }
    }
}