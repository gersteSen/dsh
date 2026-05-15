using API._Student.Dto;

namespace API._Student.Service;

public interface IStudentService
{
    Task<Guid> CreateStudentAsync(CreateStudentDto createStudentDto, CancellationToken cancellationToken = default);
    Task UpdateStudentAsync(UpdateStudentDto updateStudentDto, CancellationToken cancellationToken = default);
    Task<List<StudentDto>> GetAllStudents(CancellationToken cancellationToken = default);
    Task<StudentDto> GetStudentById(Guid studentId, CancellationToken cancellationToken = default);
    
}

