using API._Auth.Dto;

namespace API._Auth.Service;

public interface IUserService
{
    Task<string> CreateUserAsync(CreateUserDto dto, CancellationToken cancellationToken = default);
    Task<string> CreateTeacherUserAsync(CreateTeacherUserDto dto, CancellationToken cancellationToken = default);
    Task<string> CreateStudentUserAsync(CreateStudentUserDto dto, CancellationToken cancellationToken = default);
    Task UpdateUserAsync(UpdateUserDto dto, CancellationToken cancellationToken = default);
    Task DeactivateUserAsync(string userId, CancellationToken cancellationToken = default);
    Task<UserDto> GetUserByIdAsync(string userId, CancellationToken cancellationToken = default);
    Task<List<UserDto>> GetAllUsersAsync(CancellationToken cancellationToken = default);
}
