
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using zilicoPOSAPI.Daos.User;
using zilicoPOSAPI.dtos.User;
using zilicoPOSAPI.Interfaces;
using zilicoPOSAPI.Mappers;
using zilicoPOSAPI.Services;
using LoginRequest = zilicoPOSAPI.dtos.User.LoginRequest;

namespace zilicoPOSAPI.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController :ControllerBase
{
    private readonly ILogger<InventoryController> _logger;
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService, ILogger<InventoryController> logger)
    {
        _logger = logger;
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        try
        {
            if (loginRequest == null || string.IsNullOrWhiteSpace(loginRequest.Username) || string.IsNullOrWhiteSpace(loginRequest.PasswordHash))
            {
                return BadRequest("Invalid login request. Username and password are required.");
            }

            var response = await _authService.LoginAsync(loginRequest.Username, loginRequest.PasswordHash);

            if (response == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred during login.");
            return StatusCode(500, "An internal server error occurred.");
        }
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequest registerRequest)
    {
        try
        {
            if (registerRequest == null || string.IsNullOrWhiteSpace(registerRequest.Email) || string.IsNullOrWhiteSpace(registerRequest.Password))
            {
                return BadRequest("Invalid registration request. Email and password are required.");
            }

            // Map RegisterUserRequest to RegisterUserDao
            var registerUserDao = UserMapper.MapLoginUserDtoToRegisterUserDao(registerRequest);

            // Call the service with the mapped DAO
            await _authService.RegisterAsync(registerUserDao);

            return Ok("User registered successfully.");
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message); // Handle user-already-exists case
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred during registration.");
            return StatusCode(500, "An internal server error occurred.");
        }
    }

    
}