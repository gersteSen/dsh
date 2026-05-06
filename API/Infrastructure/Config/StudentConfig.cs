using API._Student;
using API._Teacher;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Infrastructure.Config;

public class StudentConfig:IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students", "student");
        
        builder.HasKey(x => x.Id);
        
        // Hat mehrere Instrumente (One-to-Many)
        builder.HasMany(x => x.Instruments)
            .WithMany(i => i.Students)
            .UsingEntity(j => j.ToTable("StudentInstruments", "ref"));
        
        // Hat mehrere Lehrer (Many-to-Many)
        builder.HasMany(x => x.Teachers)
            .WithMany(i => i.Students)
            .UsingEntity(j => j.ToTable("StudentTeachers", "ref"));
        
        // Hat mehrere Lessons 
        builder.HasMany(x => x.Lessons)
            .WithOne(i => i.Student)
            .HasForeignKey(i => i.StudentId);
        
        // Hat mehrere Rooms 
        builder.HasMany(x => x.Rooms)
            .WithMany(l => l.Students)
            .UsingEntity(j => j.ToTable("StudentRooms", "ref"));
        
        builder.HasQueryFilter(x => x.Active == false);
    }
}