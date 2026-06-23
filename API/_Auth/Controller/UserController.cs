using API._Auth.Dto;
using API._Auth.Service;
using Microsoft.AspNetCore.Mvc;

namespace API._Auth.Controller;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpPost("CreateTeacherUser")]
    public async Task<ActionResult<string>> CreateTeacherUser([FromBody] CreateTeacherUserDto dto)
    {
        var userId = await userService.CreateTeacherUserAsync(dto);
        return Ok(userId);
    }

    [HttpPost("CreateStudentUser")]
    public async Task<ActionResult<string>> CreateStudentUser([FromBody] CreateStudentUserDto dto)
    {
        var userId = await userService.CreateStudentUserAsync(dto);
        return Ok(userId);
    }

    [HttpPost("CreateUser")]
    public async Task<ActionResult<string>> CreateUser([FromBody] CreateUserDto dto)
    {
        var userId = await userService.CreateUserAsync(dto);
        return Ok(userId);
    }

    [HttpPut("UpdateUser")]
    public async Task<ActionResult> UpdateUser([FromBody] UpdateUserDto dto)
    {
        await userService.UpdateUserAsync(dto);
        return NoContent();
    }

    [HttpPut("DeactivateUser/{userId}")]
    public async Task<ActionResult> DeactivateUser(string userId)
    {
        await userService.DeactivateUserAsync(userId);
        return NoContent();
    }

    [HttpGet("GetAllUsers")]
    public async Task<ActionResult<List<UserDto>>> GetAllUsers()
    {
        var result = await userService.GetAllUsersAsync();
        return Ok(result);
    }

    [HttpGet("GetUserById/{userId}")]
    public async Task<ActionResult<UserDto>> GetUserById(string userId)
    {
        var result = await userService.GetUserByIdAsync(userId);
        return Ok(result);
    }
}
