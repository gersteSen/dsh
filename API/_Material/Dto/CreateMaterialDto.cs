namespace API._Material.Dto;

public class CreateMaterialDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? Filetype { get; set; } = string.Empty;
    public double? Filesize { get; set; } 
    public string Filesource { get; set; } = string.Empty;
    public Guid? TeacherId { get; set; }
    public Guid? StudentId { get; set; }
}