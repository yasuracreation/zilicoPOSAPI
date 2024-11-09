using zilicoPOSAPI.dtos.user;
using zilicoPOSAPI.models;

namespace zilicoPOSAPI.mappers
{
    public static class UserMapper
    {
        public static UserResponse MapUserToUserResponseDto(User user)
        {
            return new UserResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                UserType = user.UserType
            };
        }

        public static User MapCreateUserRequestToUser(CreateUserRequest createUserRequest)
        {
            return new User
            {
                Name = createUserRequest.Name,
                Email = createUserRequest.Email,
                Password = createUserRequest.Password,
                UserType = createUserRequest.UserType
            };
        }

        public static User MapUpdateUserRequestToUser(UpdateUserRequest updateUserRequest)
        {
            return new User
            {
                Name = updateUserRequest.Name,
                Email = updateUserRequest.Email,
                Password = updateUserRequest.Password,
                UserType = updateUserRequest.UserType
            };
        }
    }
}
