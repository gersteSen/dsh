using API._Room.Dto;
using API.Infrastructure;
using API.Shared;
using Microsoft.EntityFrameworkCore;

namespace API._Room.Repository;

public class RoomRepository(DshDatabaseContext context) : IRoomRepository
{
    public async Task<Guid> CreateRoomAsync(CreateRoomDto createRoomDto, CancellationToken cancellationToken = default)
    {
        var newRoom = new Room();
        newRoom.HandleCommand(createRoomDto);

        await context.Rooms.AddAsync(newRoom, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return newRoom.Id;
    }

    public async Task UpdateRoomAsync(UpdateRoomDto updateRoomDto, CancellationToken cancellationToken = default)
    {
        var room = await context.Rooms
            .Include(r => r.Lessons)
            .Include(r => r.Teachers)
            .Include(r => r.Students)
            .FirstOrDefaultAsync(r => r.Id == updateRoomDto.Id, cancellationToken);

        if (room is null) throw new KeyNotFoundException($"Kein Raum mit der Id vorhanden: {updateRoomDto.Id}");

        room.HandleCommand(updateRoomDto);

        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<RoomDto>> GetAllRooms(CancellationToken cancellationToken = default)
    {
        var rooms = await context.Rooms
            .Include(r => r.Lessons)
            .Include(r => r.Teachers)
            .Include(r => r.Students)
            .ToListAsync(cancellationToken);

        return rooms.Select(r => r.ToDto()).ToList();
    }

    public async Task<RoomDto> GetRoomById(Guid roomId, CancellationToken cancellationToken = default)
    {
        var room = await context.Rooms
            .Include(r => r.Lessons)
            .Include(r => r.Teachers)
            .Include(r => r.Students)
            .FirstOrDefaultAsync(r => r.Id == roomId, cancellationToken);

        if (room is null) throw new KeyNotFoundException($"Kein Raum mit der Id vorhanden: {roomId}");

        return room.ToDto();
    }
}

