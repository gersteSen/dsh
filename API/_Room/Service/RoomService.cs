using API._Room.Dto;
using API._Room.Repository;

namespace API._Room.Service;

public class RoomService(IRoomRepository roomRepository) : IRoomService
{
    public async Task<Guid> CreateRoomAsync(CreateRoomDto createRoomDto, CancellationToken cancellationToken = default)
    {
        return await roomRepository.CreateRoomAsync(createRoomDto, cancellationToken);
    }

    public async Task UpdateRoomAsync(UpdateRoomDto updateRoomDto, CancellationToken cancellationToken = default)
    {
        await roomRepository.UpdateRoomAsync(updateRoomDto, cancellationToken);
    }

    public async Task<List<RoomDto>> GetAllRooms(CancellationToken cancellationToken = default)
    {
        return await roomRepository.GetAllRooms(cancellationToken);
    }

    public async Task<RoomDto> GetRoomById(Guid roomId, CancellationToken cancellationToken = default)
    {
        return await roomRepository.GetRoomById(roomId, cancellationToken);
    }
}

