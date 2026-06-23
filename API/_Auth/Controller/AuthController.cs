using API._Auth.Dto;
using API._Auth.Service;
using Microsoft.AspNetCore.Mvc;

namespace API._Auth.Controller;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("Login")]
    public async Task<ActionResult<AuthResponseDto>> Login([FromBody] LoginDto dto)
    {
        var result = await authService.LoginAsync(dto);
        return Ok(result);
    }

    [HttpPost("Refresh")]
    public async Task<ActionResult<AuthResponseDto>> Refresh([FromBody] RefreshTokenDto dto)
    {
        var result = await authService.RefreshTokenAsync(dto);
        return Ok(result);
    }
}
