using API._Instrument;
using API._Lesson.Dto;
using API._Material;
using API._Room;
using API._Student;
using API._Teacher;

namespace API._Lesson;

public class Lesson
{
    public Guid Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public LessonState State { get; set; } = LessonState.Planned;

    // Zuordnung Lehrer
    public Guid TeacherId { get; set; }
    public required Teacher Teacher { get; set; }

    //Zuordnung Schueler
    public Guid StudentId { get; set; }
    public required Student Student { get; set; }

    // Zuordnung Raum
    public Guid RoomId { get; set; }
    public required Room Room { get; set; }

    // Zuordnung Instrument
    public Guid InstrumentId { get; set; }
    public required Instrument Instrument { get; set; }
    
    public List<Material> Materials { get; set; } = new List<Material>();


    public void HandleCommand(CreateLessonDto cmd)
    {
        CreateLesson(cmd);
    }

    public void HandleCommand(UpdateLessonDto cmd)
    {
        UpdateLesson(cmd);
    }

    private void CreateLesson(CreateLessonDto cmd)
    {
        Id = Guid.NewGuid();
        StartTime = cmd.StartTime;
        EndTime = cmd.EndTime;
        TeacherId = cmd.TeacherId;
        StudentId = cmd.StudentId;
        RoomId = cmd.RoomId;
        InstrumentId = cmd.InstrumentId;
    }

    private void UpdateLesson(UpdateLessonDto cmd)
    {
        StartTime = cmd.StartTime;
        EndTime = cmd.EndTime;
        TeacherId = cmd.TeacherId;
        StudentId = cmd.StudentId;
        RoomId = cmd.RoomId;
        InstrumentId = cmd.InstrumentId;
        State = cmd.State;
    }
}