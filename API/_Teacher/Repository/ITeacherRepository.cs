using API._Teacher.Dto;

namespace API._Teacher.Repository;

public interface ITeacherRepository
{   
    Task<Guid> CreateTeacherAsync(CreateTeacherDto createTeacherDto, CancellationToken cancellationToken = default);
    Task UpdateTeacherAsync(UpdateTeacherDto updateTeacherDto, CancellationToken cancellationToken = default);
    Task<List<TeacherDto>> GetAllTeachers(CancellationToken cancellationToken = default);
    Task<TeacherDto> GetTeacherById(Guid teacherId, CancellationToken cancellationToken = default);
}