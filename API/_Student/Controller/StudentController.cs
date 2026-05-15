using API._Student.Dto;
using API._Student.Service;
using Microsoft.AspNetCore.Mvc;

namespace API._Student.Controller;

[ApiController]
[Route("api/v1/[controller]")]
public class StudentController(IStudentService studentService) : ControllerBase
{
    [HttpPost("CreateStudent")]
    public async Task<ActionResult<Guid>> CreateStudent([FromBody] CreateStudentDto createStudent)
    {
        var teacherId = await studentService.CreateStudentAsync(createStudent);
        return Ok(teacherId);
    }
    
    [HttpGet("GetAllStudents")]
    public async Task<ActionResult<List<StudentDto>>> GetAllStudents()
    {
        var result = await studentService.GetAllStudents();
        return Ok(result);
    }
    
    [HttpPut("UpdateStudent")]
    public async Task<ActionResult> UpdateStudent([FromBody] UpdateStudentDto updateStudent)
    {
        await studentService.UpdateStudentAsync(updateStudent);
        return NoContent();
    }
    
    [HttpGet("GetStudentById/{studentId}")]
    public async Task<ActionResult<StudentDto>> GetStudentById(Guid studentId)
    {
        var result = await studentService.GetStudentById(studentId);
        return Ok(result);
    }
    

}