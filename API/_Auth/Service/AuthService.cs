using API._Auth.Dto;
using API._Auth.Repository;

namespace API._Auth.Service;

public class AuthService(IAuthRepository authRepository) : IAuthService
{
    public async Task<AuthResponseDto> LoginAsync(LoginDto dto, CancellationToken cancellationToken = default)
    {
        return await authRepository.LoginAsync(dto, cancellationToken);
    }

    public async Task<AuthResponseDto> RefreshTokenAsync(RefreshTokenDto dto, CancellationToken cancellationToken = default)
    {
        return await authRepository.RefreshTokenAsync(dto, cancellationToken);
    }
}
