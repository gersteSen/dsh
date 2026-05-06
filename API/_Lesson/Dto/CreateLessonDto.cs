namespace API._Lesson.Dto;

public class CreateLessonDto
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    
    // Zuordnung Lehrer
    public Guid TeacherId { get; set; }
    
    //Zuordnung Schueler
    public Guid StudentId { get; set; }
    
    // Zuordnung Raum
    public Guid RoomId { get; set; }
    
    // Zuordnung Instrument
    public Guid InstrumentId { get; set; }
}