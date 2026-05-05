using API._Instrument;
using API._Lesson;
using API._Student;
using API._Teacher.Dto;
using API.Shared;

namespace API._Teacher;

public class Teacher
{
     public Guid Id { get; set; }
     public string Avatar { get; set; } = string.Empty;
     public Sex Sex { get; set; } = Sex.Herr;
     public string FirstName { get; set; } = string.Empty;
     public string LastName { get; set; } = string.Empty;
     public DateOnly? Birtday { get; set; }
     public DateOnly? ActiveSince { get; set; }
     public Boolean Active { get; set; } = true;
     public List<Instrument> Instruments { get; set; } = new List<Instrument>();
     public List<Lesson> Lessons { get; set; } = new List<Lesson>();
     public List<Student> Students { get; set; } = new List<Student>();
     
     public string FullName => $"{Sex} {FirstName} {LastName}";
     
     
     public void HandleCommand(CreateTeacherDto cmd)
     {
          CreateTeacher(cmd);    
     }
     
     public void HandleCommand(UpdateTeacherDto cmd)
     {
          UpdateTeacher(cmd);    
     }


     private void CreateTeacher(CreateTeacherDto cmd)
     {
          Id = Guid.NewGuid();
          Avatar = cmd.Avatar;
          Sex = cmd.Sex;
          FirstName = cmd.FirstName;
          LastName = cmd.LastName;
          Birtday = cmd.Birtday;
          ActiveSince = cmd.ActiveSince;  
     }
     
     private void UpdateTeacher(UpdateTeacherDto cmd)
     {
          Avatar = cmd.Avatar;
          Sex = cmd.Sex;
          FirstName = cmd.FirstName;
          LastName = cmd.LastName;
          Birtday = cmd.Birtday;
          ActiveSince = cmd.ActiveSince;
          Active = cmd.Active;
     }
     
}