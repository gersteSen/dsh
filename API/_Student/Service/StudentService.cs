using API._Student.Dto;
using API._Student.Repository;

namespace API._Student.Service;

public class StudentService(IStudentRepository studentRepository) : IStudentService
{
    public async Task<Guid> CreateStudentAsync(CreateStudentDto createStudentDto, CancellationToken cancellationToken = default)
    {
        return await studentRepository.CreateStudentAsync(createStudentDto, cancellationToken);
    }

    public async Task UpdateStudentAsync(UpdateStudentDto updateStudentDto, CancellationToken cancellationToken = default)
    {
        await studentRepository.UpdateStudentAsync(updateStudentDto, cancellationToken);
    }

    public async Task<List<StudentDto>> GetAllStudents(CancellationToken cancellationToken = default)
    {
        return await studentRepository.GetAllStudents(cancellationToken);
    }

    public async Task<StudentDto> GetStudentById(Guid studentId, CancellationToken cancellationToken = default)
    {
        return await studentRepository.GetStudentById(studentId, cancellationToken);
    }

    public async Task<List<StudentDto>> GetStudentsByTeacherId(Guid teacherId, CancellationToken cancellationToken = default)
    {
        var students = await studentRepository.GetAllStudents(cancellationToken);
        return students
            .Where(s => s.Teachers.Any(t => t.Id == teacherId))
            .ToList();
    }
}

