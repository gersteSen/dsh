using API._Instrument;
using API._Lesson;
using API._Room;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Infrastructure.Config;

public class LessonConfig: IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.ToTable("Lessons", "lesson");
        
        builder.HasKey(x => x.Id);
        
        // Hat einen Lehrer
        builder.HasOne(x => x.Teacher)
            .WithMany(i => i.Lessons)
            .HasForeignKey(i => i.TeacherId);
        
        // Hat einen Schüler
        builder.HasOne(x => x.Student)
            .WithMany(i => i.Lessons)
            .HasForeignKey(i => i.StudentId);
        
        // Hat einen Raum
        builder.HasOne(x => x.Room)
            .WithMany(i => i.Lessons)
            .HasForeignKey(i => i.RoomId);
        
        // Hat ein Instrument
        builder.HasOne(x => x.Instrument)
            .WithMany(i => i.Lessons)
            .HasForeignKey(i => i.InstrumentId);
        
        // Hat viele Materielien
        builder.HasMany(x => x.Materials)
            .WithMany(i => i.Lessons)
            .UsingEntity(j => j.ToTable("MaterialLessons", "ref"));
        
    } 
}