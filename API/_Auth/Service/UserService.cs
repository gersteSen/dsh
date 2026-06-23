using API._Auth.Dto;
using API._Auth.Repository;
using API._Student.Dto;
using API._Student.Service;
using API._Teacher.Dto;
using API._Teacher.Services;
using Microsoft.AspNetCore.Identity;

namespace API._Auth.Service;

public class UserService(
    IUserRepository userRepository,
    ITeacherService teacherService,
    IStudentService studentService,
    UserManager<IdentityUser> userManager) : IUserService
{
    public async Task<string> CreateUserAsync(CreateUserDto dto, CancellationToken cancellationToken = default)
    {
        return await userRepository.CreateUserAsync(dto, cancellationToken);
    }

    public async Task<string> CreateTeacherUserAsync(CreateTeacherUserDto dto, CancellationToken cancellationToken = default)
    {
        var createUserDto = new CreateUserDto
        {
            Email = dto.Email,
            Password = dto.Password,
            Roles = ["TeacherRole"],
        };

        var userId = await userRepository.CreateUserAsync(createUserDto, cancellationToken);

        try
        {
            var createTeacherDto = new CreateTeacherDto
            {
                Avatar = dto.Avatar,
                Sex = dto.Sex,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Birthday = dto.Birthday,
                ActiveSince = dto.ActiveSince,
                InstrumentIds = dto.InstrumentIds,
                RoomIds = dto.RoomIds,
                LessonIds = dto.LessonIds,
                MaterialIds = dto.MaterialIds,
                StudentIds = dto.StudentIds,
            };

            await teacherService.CreateTeacherAsync(createTeacherDto, cancellationToken);
        }
        catch
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user is not null) await userManager.DeleteAsync(user);
            throw;
        }

        return userId;
    }

    public async Task<string> CreateStudentUserAsync(CreateStudentUserDto dto, CancellationToken cancellationToken = default)
    {
        var createUserDto = new CreateUserDto
        {
            Email = dto.Email,
            Password = dto.Password,
            Roles = ["StudentRole"],
        };

        var userId = await userRepository.CreateUserAsync(createUserDto, cancellationToken);

        try
        {
            var createStudentDto = new CreateStudentDto
            {
                Avatar = dto.Avatar,
                Sex = dto.Sex,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Birtday = dto.Birthday,
                ActiveSince = dto.ActiveSince,
                InstrumentIds = dto.InstrumentIds,
                TeacherIds = dto.TeacherIds,
                RoomIds = dto.RoomIds,
                LessonIds = dto.LessonIds,
                MaterialIds = dto.MaterialIds,
            };

            await studentService.CreateStudentAsync(createStudentDto, cancellationToken);
        }
        catch
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user is not null) await userManager.DeleteAsync(user);
            throw;
        }

        return userId;
    }

    public async Task UpdateUserAsync(UpdateUserDto dto, CancellationToken cancellationToken = default)
    {
        await userRepository.UpdateUserAsync(dto, cancellationToken);
    }

    public async Task DeactivateUserAsync(string userId, CancellationToken cancellationToken = default)
    {
        await userRepository.DeactivateUserAsync(userId, cancellationToken);
    }

    public async Task<UserDto> GetUserByIdAsync(string userId, CancellationToken cancellationToken = default)
    {
        return await userRepository.GetUserByIdAsync(userId, cancellationToken);
    }

    public async Task<List<UserDto>> GetAllUsersAsync(CancellationToken cancellationToken = default)
    {
        return await userRepository.GetAllUsersAsync(cancellationToken);
    }
}
