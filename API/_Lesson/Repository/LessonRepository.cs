using API._Lesson.Dto;
using API.Infrastructure;
using API.Shared;
using Microsoft.EntityFrameworkCore;

namespace API._Lesson.Repository;

public class LessonRepository(DshDatabaseContext context) : ILessonRepository
{
    public async Task<Guid> CreateLessonAsync(CreateLessonDto createLessonDto, CancellationToken cancellationToken = default)
    {
        var teacher = await context.Teachers
            .FirstOrDefaultAsync(t => t.Id == createLessonDto.TeacherId, cancellationToken)
            ?? throw new KeyNotFoundException($"Kein Lehrer mit der Id vorhanden: {createLessonDto.TeacherId}");

        var student = await context.Students
            .FirstOrDefaultAsync(s => s.Id == createLessonDto.StudentId, cancellationToken)
            ?? throw new KeyNotFoundException($"Kein Schüler mit der Id vorhanden: {createLessonDto.StudentId}");

        var room = await context.Rooms
            .FirstOrDefaultAsync(r => r.Id == createLessonDto.RoomId, cancellationToken)
            ?? throw new KeyNotFoundException($"Kein Raum mit der Id vorhanden: {createLessonDto.RoomId}");

        var instrument = await context.Instruments
            .FirstOrDefaultAsync(i => i.Id == createLessonDto.InstrumentId, cancellationToken)
            ?? throw new KeyNotFoundException($"Kein Instrument mit der Id vorhanden: {createLessonDto.InstrumentId}");

        var newLesson = new Lesson
        {
            Teacher = teacher,
            Student = student,
            Room = room,
            Instrument = instrument
        };
        newLesson.HandleCommand(createLessonDto);

        await context.Lessons.AddAsync(newLesson, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return newLesson.Id;
    }

    public async Task UpdateLessonAsync(UpdateLessonDto updateLessonDto, Guid lessonId, CancellationToken cancellationToken = default)
    {
        var lesson = await context.Lessons
            .Include(l => l.Teacher)
            .Include(l => l.Student)
            .Include(l => l.Room)
            .Include(l => l.Instrument)
            .Include(l => l.Materials)
            .FirstOrDefaultAsync(l => l.Id == lessonId, cancellationToken);

        if (lesson is null) throw new KeyNotFoundException($"Keine Unterrichtsstunde mit der Id vorhanden: {lessonId}");

        lesson.HandleCommand(updateLessonDto);

        lesson.Teacher = await context.Teachers
            .FirstOrDefaultAsync(t => t.Id == updateLessonDto.TeacherId, cancellationToken)
            ?? throw new KeyNotFoundException($"Kein Lehrer mit der Id vorhanden: {updateLessonDto.TeacherId}");

        lesson.Student = await context.Students
            .FirstOrDefaultAsync(s => s.Id == updateLessonDto.StudentId, cancellationToken)
            ?? throw new KeyNotFoundException($"Kein Schüler mit der Id vorhanden: {updateLessonDto.StudentId}");

        lesson.Room = await context.Rooms
            .FirstOrDefaultAsync(r => r.Id == updateLessonDto.RoomId, cancellationToken)
            ?? throw new KeyNotFoundException($"Kein Raum mit der Id vorhanden: {updateLessonDto.RoomId}");

        lesson.Instrument = await context.Instruments
            .FirstOrDefaultAsync(i => i.Id == updateLessonDto.InstrumentId, cancellationToken)
            ?? throw new KeyNotFoundException($"Kein Instrument mit der Id vorhanden: {updateLessonDto.InstrumentId}");

        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<LessonDto>> GetAllLessons(CancellationToken cancellationToken = default)
    {
        var lessons = await context.Lessons
            .Include(l => l.Teacher)
            .Include(l => l.Student)
            .Include(l => l.Room)
            .Include(l => l.Instrument)
            .Include(l => l.Materials)
            .ToListAsync(cancellationToken);

        return lessons.Select(l => l.ToDto()).ToList();
    }

    public async Task<LessonDto> GetLessonById(Guid lessonId, CancellationToken cancellationToken = default)
    {
        var lesson = await context.Lessons
            .Include(l => l.Teacher)
            .Include(l => l.Student)
            .Include(l => l.Room)
            .Include(l => l.Instrument)
            .Include(l => l.Materials)
            .FirstOrDefaultAsync(l => l.Id == lessonId, cancellationToken);

        if (lesson is null) throw new KeyNotFoundException($"Keine Unterrichtsstunde mit der Id vorhanden: {lessonId}");

        return lesson.ToDto();
    }
}


