using API._Instrument;
using API._Instrument.Dto;
using API._Lesson;
using API._Lesson.Dto;
using API._Material;
using API._Material.Dto;
using API._Room;
using API._Room.Dto;
using API._Student;
using API._Student.Dto;
using API._Teacher;
using API._Teacher.Dto;

namespace API.Shared;

public static class HelperExtension
{
    public static InstrumentDto ToDto(this Instrument instrument)
    {
        return new InstrumentDto
        {
            Id = instrument.Id,
            Name = instrument.Name,
            Description = instrument.Description,
            Image = instrument.Image
        };
    }

    public static TeacherDto ToDto(this Teacher teacher)
    {
        return new TeacherDto
        {
            Id = teacher.Id,
            FullName = teacher.FullName,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            ActiveSince = teacher.ActiveSince,
            Birthday = teacher.Birthday,
            Avatar = teacher.Avatar,
            Sex = teacher.Sex,
            Active = teacher.Active,
            Instruments = teacher.Instruments.Select(instrument => instrument.ToDto()).ToArray()
        };
    }

    public static StudentDto ToDto(this Student student)
    {
        return new StudentDto
        {
            Id = student.Id,
            FullName = student.FullName,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Birthday = student.Birthday,
            Avatar = student.Avatar,
            Sex = student.Sex,
            Active = student.Active,
        };
    }

    public static LessonDto ToDto(this Lesson lesson)
    {
        return new LessonDto
        {
            Id = lesson.Id,
            StartTime = lesson.StartTime,
            EndTime = lesson.EndTime,
            State = lesson.State,
            TeacherId = lesson.TeacherId,
            StudentId = lesson.StudentId,
            RoomId = lesson.RoomId,
            InstrumentId = lesson.InstrumentId
        };
    }

    public static MaterialDto ToDto(this Material material)
    {
        return new MaterialDto
        {
            Id = material.Id,
            Name = material.Name,
            Description = material.Description,
            Filetype = material.Filetype,
            Filesize = material.Filesize,
            Filesource = material.Filesource,
            TeacherId = material.TeacherId,
            StudentId = material.StudentId,
            CreatedAt = material.CreatedAt,
            UpdatedAt = material.UpdatedAt
        };
    }

    public static RoomDto ToDto(this Room room)
    {
        return new RoomDto
        {
            Id = room.Id,
            Name = room.Name,
            Description = room.Description,
            Address = room.Address is not null ? new AddressDto
            {
                Street = room.Address.Street,
                City = room.Address.City,
                ZipCode = room.Address.ZipCode,
                Longitude = room.Address.Longitude,
                Latitude = room.Address.Latitude
            } : null
        };
    }
}