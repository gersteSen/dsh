using API._Auth.Dto;

namespace API._Auth.Repository;

public interface IUserRepository
{
    Task<string> CreateUserAsync(CreateUserDto dto, CancellationToken cancellationToken = default);
    Task UpdateUserAsync(UpdateUserDto dto, CancellationToken cancellationToken = default);
    Task DeactivateUserAsync(string userId, CancellationToken cancellationToken = default);
    Task<UserDto> GetUserByIdAsync(string userId, CancellationToken cancellationToken = default);
    Task<List<UserDto>> GetAllUsersAsync(CancellationToken cancellationToken = default);
}
