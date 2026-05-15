using API._Lesson.Dto;

namespace API._Lesson.Dto;

public class LessonDto
{
    public Guid Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public LessonState State { get; set; } = LessonState.Planned;

    public Guid TeacherId { get; set; }
    public Guid StudentId { get; set; }
    public Guid RoomId { get; set; }
    public Guid InstrumentId { get; set; }
}


