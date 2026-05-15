using API._Instrument.Dto;

namespace API._Instrument.Repository;

public interface IInstrumentRepository
{
    Task<Guid> CreateInstrumentAsync(CreateInstrumentDto createInstrumentDto, CancellationToken cancellationToken = default);
    Task UpdateInstrumentAsync(UpdateInstrumentDto updateInstrumentDto, CancellationToken cancellationToken = default);
    Task<List<InstrumentDto>> GetAllInstruments(CancellationToken cancellationToken = default);
    Task<InstrumentDto> GetInstrumentById(Guid instrumentId, CancellationToken cancellationToken = default);
}

