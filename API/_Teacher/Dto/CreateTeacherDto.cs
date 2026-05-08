using API.Shared;

namespace API._Teacher.Dto;

public class CreateTeacherDto
{
    public string Avatar { get; set; } = string.Empty;
    public Sex Sex { get; set; } = Sex.Herr;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateOnly? Birthday { get; set; }
    public DateOnly? ActiveSince { get; set; }
    
    public List<Guid> InstrumentIds { get; set; } = new();
    public List<Guid> RoomIds { get; set; } = new();
    public List<Guid> LessonIds { get; set; } = new();
    public List<Guid> MaterialIds { get; set; } = new();
    public List<Guid> StudentIds { get; set; } = new();
}