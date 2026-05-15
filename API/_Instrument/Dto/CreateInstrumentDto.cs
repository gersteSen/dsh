namespace API._Instrument.Dto;

public class CreateInstrumentDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? Image { get; set; } = string.Empty;
    public List<Guid> TeacherIds { get; set; } = new List<Guid>();
    public List<Guid> StudentIds { get; set; } = new List<Guid>();
    public List<Guid> LessonIds { get; set; } = new List<Guid>();
}