using API._Room.Dto;

namespace API._Room;

public class Room
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Address? Address { get; set; }
    
    public void HandleCommand(CreateRoomDto cmd)
    {
        Id = Guid.NewGuid();
        Name = cmd.Name;
        Description = cmd.Description;
        Address = cmd.Address is not null ? new Address
        {
            Street = cmd.Address.Street,
            City = cmd.Address.City,
            ZipCode = cmd.Address.ZipCode,
            Latitude = cmd.Address.Latitude ?? 0,
            Longitude = cmd.Address.Longitude ?? 0
        } : null;
    }
    
    public void HandleCommand(UpdateRoomDto cmd)
    {
        Name = cmd.Name;
        Description = cmd.Description;
        Address = cmd.Address is not null ? new Address
        {
            Street = cmd.Address.Street,
            City = cmd.Address.City,
            ZipCode = cmd.Address.ZipCode,
            Latitude = cmd.Address.Latitude ?? 0,
            Longitude = cmd.Address.Longitude ?? 0
        } : null;
    }
    
    
}