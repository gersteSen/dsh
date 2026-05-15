using API._Student.Dto;
using API._Student.Repository;
using API._Teacher.Dto;
using API._Teacher.Repository;

namespace API._Teacher.Services;

public class TeacherService(ITeacherRepository teacherRepository, IStudentRepository studentRepository):ITeacherService
{
    public async Task<Guid> CreateTeacherAsync(CreateTeacherDto createTeacherDto, CancellationToken cancellationToken = default)
    {
        return await teacherRepository.CreateTeacherAsync(createTeacherDto, cancellationToken);
    }

    public async Task UpdateTeacherAsync(UpdateTeacherDto updateTeacherDto, CancellationToken cancellationToken = default)
    {
        await teacherRepository.UpdateTeacherAsync(updateTeacherDto, cancellationToken);
    }

    public async Task<List<TeacherDto>> GetAllTeachers(CancellationToken cancellationToken = default)
    {
        return await teacherRepository.GetAllTeachers(cancellationToken);
    }

    public async Task<TeacherDto> GetTeacherById(Guid teacherId, CancellationToken cancellationToken = default)
    {
        return await teacherRepository.GetTeacherById(teacherId, cancellationToken);
    }
    
    public async Task<List<StudentDto>> GetStudentsByTeacherId(Guid teacherId, CancellationToken cancellationToken = default)
    {
        return await teacherRepository.GetAllStudentsByTeacherId(teacherId,cancellationToken);

    }
}