using Microsoft.AspNetCore.Mvc;
using zilicoPOSAPI.Dtos.Token;
using zilicoPOSAPI.Interfaces;

namespace zilicoPOSAPI.Controllers;

[ApiController]
[Route("api/token")]
public class TokenController : ControllerBase
{
    private readonly ITokenService _tokenService;

    public TokenController(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost("generate")]
    public IActionResult GenerateToken([FromBody] TokenRequest request)
    {
        if ( request.UserId == Guid.Empty || request.UserGroupId == Guid.Empty)
        {
            return BadRequest("Invalid request.");
        }

        var token = _tokenService.GenerateToken(request.UserId, request.UserGroupId);
        return Ok(new { Token = token });
    }

    [HttpPost("validate")]
    public IActionResult ValidateToken([FromBody] ValidateTokenRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Token))
        {
            return BadRequest("Invalid token.");
        }

        try
        {
            var userId = _tokenService.ValidateToken(request.Token);
            return Ok(new { UserId = userId });
        }
        catch (Exception ex)
        {
            return Unauthorized(new { Message = ex.Message });
        }
    }
}
