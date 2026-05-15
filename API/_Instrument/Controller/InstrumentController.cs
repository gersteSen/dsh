using API._Instrument.Dto;
using API._Instrument.Service;
using Microsoft.AspNetCore.Mvc;

namespace API._Instrument.Controller;

[ApiController]
[Route("api/v1/[controller]")]
public class InstrumentController(IInstrumentService instrumentService) : ControllerBase
{
    [HttpPost("CreateInstrument")]
    public async Task<ActionResult<Guid>> CreateInstrument([FromBody] CreateInstrumentDto createInstrumentDto, CancellationToken cancellationToken)
    {
        var instrumentId = await instrumentService.CreateInstrumentAsync(createInstrumentDto, cancellationToken);
        return Ok(instrumentId);
    }

    [HttpPut("UpdateInstrument")]
    public async Task<ActionResult> UpdateInstrument([FromBody] UpdateInstrumentDto updateInstrumentDto, CancellationToken cancellationToken)
    {
        await instrumentService.UpdateInstrumentAsync(updateInstrumentDto, cancellationToken);
        return NoContent();
    }

    [HttpGet("GetAllInstruments")]
    public async Task<ActionResult<List<InstrumentDto>>> GetAllInstruments(CancellationToken cancellationToken)
    {
        var result = await instrumentService.GetAllInstruments(cancellationToken);
        return Ok(result);
    }

    [HttpGet("GetInstrumentById/{instrumentId}")]
    public async Task<ActionResult<InstrumentDto>> GetInstrumentById(Guid instrumentId, CancellationToken cancellationToken)
    {
        var result = await instrumentService.GetInstrumentById(instrumentId, cancellationToken);
        return Ok(result);
    }
}

