namespace API._Room.Dto;

public class CreateAddressDto
{
    public string Street { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public double? Longitude { get; set; }
    public double? Latitude { get; set; }
}