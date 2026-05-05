namespace API._Room.Dto;

public class CreateRoomDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public CreateAddressDto? Address { get; set; }
}