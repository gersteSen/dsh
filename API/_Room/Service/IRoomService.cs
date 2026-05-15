using API._Room.Dto;

namespace API._Room.Service;

public interface IRoomService
{
    Task<Guid> CreateRoomAsync(CreateRoomDto createRoomDto, CancellationToken cancellationToken = default);
    Task UpdateRoomAsync(UpdateRoomDto updateRoomDto, CancellationToken cancellationToken = default);
    Task<List<RoomDto>> GetAllRooms(CancellationToken cancellationToken = default);
    Task<RoomDto> GetRoomById(Guid roomId, CancellationToken cancellationToken = default);
}

