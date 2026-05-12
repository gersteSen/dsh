using API._Instrument;
using API._Lesson;
using API._Material;
using API._Room;
using API._Student.Dto;
using API._Teacher;
using API.Shared;

namespace API._Student;

public class Student
{
    public Guid Id { get; set; }
    public string Avatar { get; set; } = string.Empty;
    public Sex Sex { get; set; } = Sex.Herr;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateOnly? Birthday { get; set; }
    public DateOnly? ActiveSince { get; set; }
    public Boolean Active { get; set; } = true;
    public List<Teacher> Teachers { get; set; } = new List<Teacher>();
    public List<Instrument> Instruments { get; set; } = new List<Instrument>();
    public List<Lesson> Lessons { get; set; } = new List<Lesson>();
    public List<Room> Rooms { get; set; } = new List<Room>();
    public List<Material> Materials { get; set; } = new List<Material>();
     
    public string FullName => $"{Sex} {FirstName} {LastName}";
    
    public void HandleCommand(CreateStudentDto cmd)
    {
        CreateStudent(cmd);    
    }
     
    public void HandleCommand(UpdateStudentDto cmd)
    {
        UpdateStudent(cmd);    
    }


    private void CreateStudent(CreateStudentDto cmd)
    {
        Id = Guid.NewGuid();
        Avatar = cmd.Avatar ?? string.Empty;
        Sex = cmd.Sex;
        FirstName = cmd.FirstName;
        LastName = cmd.LastName;
        Birthday = cmd.Birtday;
        ActiveSince = cmd.ActiveSince;  
    }
     
    private void UpdateStudent(UpdateStudentDto cmd)
    {
        Avatar = cmd.Avatar;
        Sex = cmd.Sex;
        FirstName = cmd.FirstName;
        LastName = cmd.LastName;
        Birthday = cmd.Birtday;
        ActiveSince = cmd.ActiveSince;
        Active = cmd.Active;
    }
}