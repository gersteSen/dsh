using API._Instrument.Dto;
using API._Instrument.Repository;

namespace API._Instrument.Service;

public class InstrumentService(IInstrumentRepository instrumentRepository) : IInstrumentService
{
    public async Task<Guid> CreateInstrumentAsync(CreateInstrumentDto createInstrumentDto, CancellationToken cancellationToken = default)
    {
        return await instrumentRepository.CreateInstrumentAsync(createInstrumentDto, cancellationToken);
    }

    public async Task UpdateInstrumentAsync(UpdateInstrumentDto updateInstrumentDto, CancellationToken cancellationToken = default)
    {
        await instrumentRepository.UpdateInstrumentAsync(updateInstrumentDto, cancellationToken);
    }

    public async Task<List<InstrumentDto>> GetAllInstruments(CancellationToken cancellationToken = default)
    {
        return await instrumentRepository.GetAllInstruments(cancellationToken);
    }

    public async Task<InstrumentDto> GetInstrumentById(Guid instrumentId, CancellationToken cancellationToken = default)
    {
        return await instrumentRepository.GetInstrumentById(instrumentId, cancellationToken);
    }
}

