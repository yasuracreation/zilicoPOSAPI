using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using zilicoPOSAPI.dtos.user;
using zilicoPOSAPI.interfaces;
using zilicoPOSAPI.models;
using zilicoPOSAPI.mappers;
using System.Threading.Tasks;

namespace zilicoPOSAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        // Get all users
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetUsersAsync();
            var userResponse = users.Select(UserMapper.MapUserToUserResponseDto).ToList();
            return Ok(userResponse);
        }

        // Get user by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            var user = await _userRepository.GetUserAsync(id);
            if (user == null)
                return NotFound();

            return Ok(UserMapper.MapUserToUserResponseDto(user));
        }

        // Create new user
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest createUserRequest)
        {
            _logger.LogInformation("creating user");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdUser = await _userRepository.createUser(createUserRequest);
            if (createdUser == null)
                return BadRequest("User creation failed.");

            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, UserMapper.MapUserToUserResponseDto(createdUser));
        }

        // Update user
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody]UpdateUserRequest updateUserRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUser = await _userRepository.GetUserAsync(id);
            if (existingUser == null)
                return NotFound();

            var updatedUser = await _userRepository.updateUser(id, updateUserRequest);
            return Ok(UserMapper.MapUserToUserResponseDto(updatedUser));
        }

        // Delete user
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var existingUser = await _userRepository.GetUserAsync(id);
            if (existingUser == null)
                return NotFound();

            var deletedUser = await _userRepository.deleteUser(id);
            return Ok(UserMapper.MapUserToUserResponseDto(deletedUser));
        }
    }
}
