using API._Room.Dto;
using API._Room.Service;
using Microsoft.AspNetCore.Mvc;

namespace API._Room.Controller;

[ApiController]
[Route("api/v1/[controller]")]
public class RoomController(IRoomService roomService) : ControllerBase
{
    [HttpPost("CreateRoom")]
    public async Task<ActionResult<Guid>> CreateRoom([FromBody] CreateRoomDto createRoomDto, CancellationToken cancellationToken)
    {
        var roomId = await roomService.CreateRoomAsync(createRoomDto, cancellationToken);
        return Ok(roomId);
    }

    [HttpPut("UpdateRoom")]
    public async Task<ActionResult> UpdateRoom([FromBody] UpdateRoomDto updateRoomDto, CancellationToken cancellationToken)
    {
        await roomService.UpdateRoomAsync(updateRoomDto, cancellationToken);
        return NoContent();
    }

    [HttpGet("GetAllRooms")]
    public async Task<ActionResult<List<RoomDto>>> GetAllRooms(CancellationToken cancellationToken)
    {
        var result = await roomService.GetAllRooms(cancellationToken);
        return Ok(result);
    }

    [HttpGet("GetRoomById/{roomId}")]
    public async Task<ActionResult<RoomDto>> GetRoomById(Guid roomId, CancellationToken cancellationToken)
    {
        var result = await roomService.GetRoomById(roomId, cancellationToken);
        return Ok(result);
    }
}

