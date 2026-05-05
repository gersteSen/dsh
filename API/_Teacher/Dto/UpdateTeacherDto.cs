using API.Shared;

namespace API._Teacher.Dto;

public class UpdateTeacherDto
{
    public string Avatar { get; set; } = string.Empty;
    public Sex Sex { get; set; } = Sex.Herr;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateOnly? Birtday { get; set; }
    public DateOnly? ActiveSince { get; set; }
    public Boolean Active { get; set; } = true;
}