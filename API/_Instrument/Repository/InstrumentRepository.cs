using API._Instrument.Dto;
using API.Infrastructure;
using Microsoft.EntityFrameworkCore;
using static API.Shared.HelperExtension;

namespace API._Instrument.Repository;

public class InstrumentRepository(DshDatabaseContext context) : IInstrumentRepository
{
    public async Task<Guid> CreateInstrumentAsync(CreateInstrumentDto createInstrumentDto, CancellationToken cancellationToken = default)
    {
        var newInstrument = new Instrument();
        newInstrument.HandleCommand(createInstrumentDto);
        await LoadRelatedEntitiesAsync(newInstrument, createInstrumentDto.TeacherIds, createInstrumentDto.StudentIds, createInstrumentDto.LessonIds, cancellationToken);

        await context.Instruments.AddAsync(newInstrument, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return newInstrument.Id;
    }

    public async Task UpdateInstrumentAsync(UpdateInstrumentDto updateInstrumentDto, CancellationToken cancellationToken = default)
    {
        var instrument = await context.Instruments
            .Include(i => i.Teachers)
            .Include(i => i.Students)
            .Include(i => i.Lessons)
            .FirstOrDefaultAsync(i => i.Id == updateInstrumentDto.Id, cancellationToken);

        if (instrument is null) throw new KeyNotFoundException($"Instrument '{updateInstrumentDto.Name}' nicht gefunden.");

        instrument.HandleCommand(updateInstrumentDto);
        await LoadRelatedEntitiesAsync(instrument, updateInstrumentDto.TeacherIds, updateInstrumentDto.StudentIds, updateInstrumentDto.LessonIds, cancellationToken);

        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<InstrumentDto>> GetAllInstruments(CancellationToken cancellationToken = default)
    {
        var instruments = await context.Instruments
            .Include(i => i.Teachers)
            .Include(i => i.Students)
            .Include(i => i.Lessons)
            .ToListAsync(cancellationToken);

        return instruments.Select(i => i.ToDto()).ToList();
    }

    public async Task<InstrumentDto> GetInstrumentById(Guid instrumentId, CancellationToken cancellationToken = default)
    {
        var instrument = await context.Instruments
            .Include(i => i.Teachers)
            .Include(i => i.Students)
            .Include(i => i.Lessons)
            .FirstOrDefaultAsync(i => i.Id == instrumentId, cancellationToken);

        if (instrument is null) throw new KeyNotFoundException($"Kein Instrument mit der Id vorhanden: {instrumentId}");

        return instrument.ToDto();
    }

    private async Task LoadRelatedEntitiesAsync(
        Instrument instrument,
        List<Guid> teacherIds,
        List<Guid> studentIds,
        List<Guid> lessonIds,
        CancellationToken cancellationToken)
    {
        instrument.Teachers = await context.Teachers
            .Where(t => teacherIds.Contains(t.Id))
            .ToListAsync(cancellationToken);

        instrument.Students = await context.Students
            .Where(s => studentIds.Contains(s.Id))
            .ToListAsync(cancellationToken);

        instrument.Lessons = await context.Lessons
            .Where(l => lessonIds.Contains(l.Id))
            .ToListAsync(cancellationToken);
    }
}



