using API.Shared;

namespace API._Auth.Dto;

public class CreateTeacherUserDto
{
    // Auth
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    // Teacher-Profil
    public string Avatar { get; set; } = string.Empty;
    public Sex Sex { get; set; } = Sex.Herr;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateOnly? Birthday { get; set; }
    public DateOnly? ActiveSince { get; set; }
    public List<Guid> InstrumentIds { get; set; } = [];
    public List<Guid> RoomIds { get; set; } = [];
    public List<Guid> LessonIds { get; set; } = [];
    public List<Guid> MaterialIds { get; set; } = [];
    public List<Guid> StudentIds { get; set; } = [];
}
