using API._Instrument.Dto;

namespace API._Instrument;

public class Instrument
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? Image { get; set; } = string.Empty;
    
    public void HandleCommand(CreateInstrumentDto cmd)
    {
        CreateInstrument(cmd);    
    }
     
    public void HandleCommand(UpdateInstrumentDto cmd)
    {
        UpdateInstrument(cmd);    
    }
    
    private void CreateInstrument(CreateInstrumentDto cmd)
    {
        Id = Guid.NewGuid();
        Name = cmd.Name;
        Description = cmd.Description;
        Image = cmd.Image;  
    }
    
    private void UpdateInstrument(UpdateInstrumentDto cmd)
    {
        Name = cmd.Name;
        Description = cmd.Description;
        Image = cmd.Image;  
    }
}