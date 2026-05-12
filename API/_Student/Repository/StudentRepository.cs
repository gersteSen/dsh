using API._Student.Dto;
using API.Infrastructure;
using API.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace API._Student.Repository;

public class StudentRepository(DshDatabaseContext context): IStudentRepository
{
    public async Task<Guid> CreateStudentAsync(CreateStudentDto createStudentDto, CancellationToken cancellationToken = default)
    {
        var newStudent = new Student();
        
        newStudent.HandleCommand(createStudentDto);
        
        await LoadRelatedEntitiesAsync(
            newStudent,
            createStudentDto.InstrumentIds,
            createStudentDto.RoomIds,
            createStudentDto.LessonIds,
            createStudentDto.MaterialIds,
            createStudentDto.TeacherIds,
            cancellationToken);
        
        context.Students.Add(newStudent);
        
        await context.SaveChangesAsync(cancellationToken);
        
        return newStudent.Id;
    }

    public async Task UpdateStudentAsync(UpdateStudentDto updateStudentDto, CancellationToken cancellationToken = default)
    {
        var student = await context.Students
            .Include(s => s.Teachers)
            .Include(s => s.Lessons)
            .Include(s => s.Materials)
            .Include(s => s.Rooms)
            .FirstOrDefaultAsync(t => t.Id == updateStudentDto.Id, cancellationToken);
        
        if(student is null) throw new KeyNotFoundException($"Kein Schüler vorhanden: {updateStudentDto.FirstName} {updateStudentDto.LastName}");

        student.HandleCommand(updateStudentDto);
        await LoadRelatedEntitiesAsync(
            student, 
            updateStudentDto.InstrumentIds, 
            updateStudentDto.RoomIds,
            updateStudentDto.LessonIds, 
            updateStudentDto.MaterialIds, 
            updateStudentDto.TeacherIds, 
            cancellationToken);
        
        await context.SaveChangesAsync(cancellationToken);
        
    }

    public async Task<List<StudentDto>> GetAllStudents(CancellationToken cancellationToken = default)
    {
        var students = await context.Students
            .Include(s => s.Teachers)
            .Include(s => s.Lessons)
            .Include(s => s.Materials)
            .Include(s => s.Rooms)
            .ToListAsync(cancellationToken);

        return students.Select(s => s.ToDto()).ToList();
    }

    public async Task<StudentDto> GetStudentById(Guid studentId, CancellationToken cancellationToken = default)
    {
        var student = await context.Students
            .Include(s => s.Teachers)
            .Include(s => s.Lessons)
            .Include(s => s.Materials)
            .Include(s => s.Rooms)
            .FirstOrDefaultAsync(t => t.Id == studentId, cancellationToken);
        
        if(student is null) throw new KeyNotFoundException($"Kein Schüler mit der Id vorhanden: {studentId}");
        
        return student.ToDto();

    }
    
    
    private async Task LoadRelatedEntitiesAsync(
        Student student,
        List<Guid> instrumentIds,
        List<Guid> roomIds,
        List<Guid> lessonIds,
        List<Guid> materialIds,
        List<Guid> studentIds,
        CancellationToken cancellationToken)
    {
        student.Instruments = await context.Instruments
            .Where(i => instrumentIds.Contains(i.Id))
            .ToListAsync(cancellationToken);

        student.Rooms = await context.Rooms
            .Where(r => roomIds.Contains(r.Id))
            .ToListAsync(cancellationToken);

        student.Lessons = await context.Lessons
            .Where(l => lessonIds.Contains(l.Id))
            .ToListAsync(cancellationToken);

        student.Materials = await context.Materials
            .Where(m => materialIds.Contains(m.Id))
            .ToListAsync(cancellationToken);

        student.Teachers = await context.Teachers
            .Where(s => studentIds.Contains(s.Id))
            .ToListAsync(cancellationToken);
    }
}