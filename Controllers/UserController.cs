using Microsoft.AspNetCore.Mvc;
using zilicoPOSAPI.dtos.User;
using zilicoPOSAPI.Interfaces;
using zilicoPOSAPI.Mappers;
using zilicoPOSAPI.Services;

namespace zilicoPOSAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserService _userService;

        public UserController(ILogger<UserController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        //Get all users
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            var userResponse = users.Select(UserMapper.MapUserToUserResponseDto).ToList();
            return Ok(userResponse);
        }
    //
    // Get user by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser([FromRoute] Guid id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null)
            return NotFound();
    
        return Ok(UserMapper.MapUserToUserResponseDto(user));
    }
    //
    //     // Create new user
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest createUserRequest)
    {
        _logger.LogInformation("creating user");
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
    
        var createdUser = await _userService.CreateUserAsync(createUserRequest);
        if (createdUser == null)
            return BadRequest("User creation failed.");
    
        return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, UserMapper.MapUserToUserResponseDto(createdUser));
    }
    //
    //     // Update user
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody]UpdateUserRequest updateUserRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
    
        var updatedUser = await _userService.UpdateUserAsync(id,updateUserRequest);
        
        return Ok(UserMapper.MapUserToUserResponseDto(updatedUser));
    }
    //
    //     // Delete user
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser([FromRoute] int id)
    {
        var deletedUser = await _userService.DeleteUserAsync(id);
        return Ok(UserMapper.MapUserToUserResponseDto(deletedUser));
    }
    }
}
