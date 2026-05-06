using API._Instrument;
using API._Material;
using API._Room;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Infrastructure.Config;

public class MaterialConfig:IEntityTypeConfiguration<Material>
{
    public void Configure(EntityTypeBuilder<Material> builder)
    {
        builder.ToTable("Materials", "material");
        
        builder.HasKey(x => x.Id);
        
        // Wird für mehrere Lessons benutzt
        builder.HasMany(x => x.Lessons)
            .WithMany(i => i.Materials)
            .UsingEntity(j => j.ToTable("MaterialLessons", "ref"));
            
        // Wird von einem Lehrer erstellt
        builder.HasOne(x => x.Teacher)
            .WithMany(i => i.Materials)
            .HasForeignKey(i => i.TeacherId);
        
        // Wird von einem Schüler erstellt
        builder.HasOne(x => x.Student)
            .WithMany(i => i.Materials)
            .HasForeignKey(i => i.StudentId);
        
    } 
}