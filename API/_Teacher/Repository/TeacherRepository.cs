using API._Student.Dto;
using API._Teacher.Dto;
using API.Infrastructure;
using API.Shared;
using Microsoft.EntityFrameworkCore;

namespace API._Teacher.Repository;

public class TeacherRepository(DshDatabaseContext context) : ITeacherRepository
{
    public async Task<Guid> CreateTeacherAsync(CreateTeacherDto createTeacherDto, CancellationToken cancellationToken = default)
    {
        var newTeacher = new Teacher();
        newTeacher.HandleCommand(createTeacherDto);
        await LoadRelatedEntitiesAsync(newTeacher, createTeacherDto.InstrumentIds, createTeacherDto.RoomIds,
            createTeacherDto.LessonIds, createTeacherDto.MaterialIds, createTeacherDto.StudentIds, cancellationToken);

        await context.Teachers.AddAsync(newTeacher, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        
        return newTeacher.Id;
    }

    public async Task UpdateTeacherAsync(UpdateTeacherDto updateTeacherDto, CancellationToken cancellationToken = default)
    {
        var teacher = await context.Teachers
            .Include(t => t.Instruments)
            .Include(t => t.Rooms)
            .Include(t => t.Lessons)
            .Include(t => t.Materials)
            .Include(t => t.Students)
            .FirstOrDefaultAsync(t => t.Id == updateTeacherDto.Id, cancellationToken);

        if (teacher is null) throw new KeyNotFoundException($"Lehrer {updateTeacherDto.LastName}, {updateTeacherDto.FirstName} nicht gefunden.");

        teacher.HandleCommand(updateTeacherDto);
        await LoadRelatedEntitiesAsync(teacher, updateTeacherDto.InstrumentIds, updateTeacherDto.RoomIds,
            updateTeacherDto.LessonIds, updateTeacherDto.MaterialIds, updateTeacherDto.StudentIds, cancellationToken);

        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<TeacherDto>> GetAllTeachers(CancellationToken cancellationToken = default)
    {
        var teachers = await context.Teachers
            .Include(t => t.Instruments)
            .Include(t => t.Rooms)
            .Include(t => t.Lessons)
            .Include(t => t.Materials)
            .Include(t => t.Students)
            .ToListAsync(cancellationToken);

        return teachers.Select(teacher => teacher.ToDto()).ToList();
    }

    public async Task<TeacherDto> GetTeacherById(Guid teacherId, CancellationToken cancellationToken = default)
    {
        var teacher = await context.Teachers
            .Include(t => t.Instruments)
            .Include(t => t.Rooms)
            .Include(t => t.Lessons)
            .Include(t => t.Materials)
            .Include(t => t.Students)
            .FirstOrDefaultAsync(t => t.Id == teacherId, cancellationToken);

        if (teacher is null) throw new KeyNotFoundException($"Kein Lehrer mit der Id vorhanden: {teacherId}");

        return teacher.ToDto();
    }

    public async Task<List<StudentDto>> GetAllStudentsByTeacherId(Guid teacherId, CancellationToken cancellationToken = default)
    {
        var teacher = await context.Teachers
            .Include(t => t.Students)
            .FirstOrDefaultAsync(t => t.Id == teacherId, cancellationToken);

        if (teacher is null) throw new KeyNotFoundException($"Kein Lehrer mit der Id vorhanden: {teacherId}");

        return teacher.Students.Select(student => student.ToDto()).ToList();
    }

    private async Task LoadRelatedEntitiesAsync(
        Teacher teacher,
        List<Guid> instrumentIds,
        List<Guid> roomIds,
        List<Guid> lessonIds,
        List<Guid> materialIds,
        List<Guid> studentIds,
        CancellationToken cancellationToken)
    {
        teacher.Instruments = await context.Instruments
            .Where(i => instrumentIds.Contains(i.Id))
            .ToListAsync(cancellationToken);

        teacher.Rooms = await context.Rooms
            .Where(r => roomIds.Contains(r.Id))
            .ToListAsync(cancellationToken);

        teacher.Lessons = await context.Lessons
            .Where(l => lessonIds.Contains(l.Id))
            .ToListAsync(cancellationToken);

        teacher.Materials = await context.Materials
            .Where(m => materialIds.Contains(m.Id))
            .ToListAsync(cancellationToken);

        teacher.Students = await context.Students
            .Where(s => studentIds.Contains(s.Id))
            .ToListAsync(cancellationToken);
    }
}