namespace API._Material.Dto;

public class MaterialDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? Filetype { get; set; }
    public double? Filesize { get; set; }
    public string Filesource { get; set; } = string.Empty;
    public Guid? TeacherId { get; set; }
    public Guid? StudentId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

