using API._Instrument;
using API._Lesson;
using API._Material;
using API._Room;
using API._Teacher.Dto;
using API.Shared;

namespace API._Student.Dto;

public class StudentDto
{
    public Guid Id { get; set; }
    public string Avatar { get; set; } = string.Empty;
    public Sex Sex { get; set; } = Sex.Herr;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public DateOnly? Birthday { get; set; }
    public DateOnly? ActiveSince { get; set; }
    public Boolean Active { get; set; } = true;
}

