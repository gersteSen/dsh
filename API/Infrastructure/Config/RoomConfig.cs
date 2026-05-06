using API._Instrument;
using API._Room;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Infrastructure.Config;

public class RoomConfig:IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.ToTable("Rooms", "room");
        
        builder.HasKey(x => x.Id);

        // Address wird als JSONB in der Rooms-Tabelle gespeichert
        builder.OwnsOne(x => x.Address, a => a.ToJson());
        
        // Wird für mehrere Lessons benutzt
        builder.HasMany(x => x.Lessons)
            .WithOne(i => i.Room)
            .HasForeignKey(i => i.RoomId)
            .OnDelete(DeleteBehavior.SetNull);
        
        // Wird von mehreren Lehrern benutzt
        builder.HasMany(x => x.Teachers)
            .WithMany(i => i.Rooms)
            .UsingEntity(j => j.ToTable("TeacherRooms", "ref"));
        
    } 
}