using API._Instrument;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Infrastructure.Config;

public class InstrumentConfig:IEntityTypeConfiguration<Instrument>
{
    public void Configure(EntityTypeBuilder<Instrument> builder)
    {
        builder.ToTable("Instruments", "instrument");
        
        builder.HasKey(x => x.Id);
        
        // Wird von mehreren Lehrern benutzt
        builder.HasMany(x => x.Teachers)
            .WithMany(i => i.Instruments)
            .UsingEntity(j => j.ToTable("TeacherInstruments", "ref"));
        
        // Wird von mehreren Students benutzt
        builder.HasMany(x => x.Students)
            .WithMany(i => i.Instruments)
            .UsingEntity(j => j.ToTable("StudentInstruments", "ref"));
        
    } 
}