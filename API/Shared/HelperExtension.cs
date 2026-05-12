using API._Student;
using API._Student.Dto;
using API._Teacher;
using API._Teacher.Dto;

namespace API.Shared;

public static class HelperExtension
{
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
            Active = teacher.Active
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
            Active = student.Active
        };
    }
}