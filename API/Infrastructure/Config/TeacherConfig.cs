using API._Teacher;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Infrastructure.Config;

public class TeacherConfig:IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.ToTable("Teachers", "teacher");
        
        builder.HasKey(x => x.Id);
        
        // Hat mehrere Instrumente (Many-to-Many)
        builder.HasMany(x => x.Instruments)
            .WithMany(i => i.Teachers)
            .UsingEntity(j => j.ToTable("TeacherInstruments", "ref"));
        
        // Hat mehrere Students 
        builder.HasMany(x => x.Students)
            .WithMany(i => i.Teachers)
            .UsingEntity(j => j.ToTable("StudentTeachers", "ref"));
        
        // Hat mehrere Lessons 
        builder.HasMany(x => x.Lessons)
            .WithOne(l => l.Teacher)
            .HasForeignKey(l => l.TeacherId);
        
        // Hat mehrere Rooms 
        builder.HasMany(x => x.Rooms)
            .WithMany(l => l.Teachers)
            .UsingEntity(j => j.ToTable("TeacherRooms", "ref"));
        
        builder.HasQueryFilter(x => x.Active == true);
    }
}