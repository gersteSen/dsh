using API._Instrument.Dto;
using API.Shared;

namespace API._Teacher.Dto;

public class TeacherDto
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
    public TeacherInstrumentDto[] Instruments { get; set; } = Array.Empty<TeacherInstrumentDto>();
}