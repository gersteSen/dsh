using API._Student.Dto;
using API._Teacher.Dto;
using API._Teacher.Services;
using Microsoft.AspNetCore.Mvc;

namespace API._Teacher.Controller;

[ApiController]
[Route("api/v1/[controller]")]
public class TeacherController(ITeacherService teacherService) : ControllerBase
{
    [HttpPost("CreateTeacher")]
    public async Task<ActionResult<Guid>> CreateTeacher([FromBody] CreateTeacherDto createTeacherDto)
    {
        var teacherId = await teacherService.CreateTeacherAsync(createTeacherDto);
        return Ok(teacherId);
    }

    [HttpPut("UpdateTeacher")]
    public async Task<ActionResult> UpdateTeacher([FromBody] UpdateTeacherDto updateTeacherDto)
    {
        await teacherService.UpdateTeacherAsync(updateTeacherDto);
        return NoContent();
    }

    [HttpGet("GetAllTeachers")]
    public async Task<ActionResult<List<TeacherDto>>> GetAllTeachers()
    {
        var result = await teacherService.GetAllTeachers();
        return Ok(result);
    }

    [HttpGet("GetTeacherById/{teacherId}")]
    public async Task<ActionResult<TeacherDto>> GetTeacherById(Guid teacherId)
    {
        var result = await teacherService.GetTeacherById(teacherId);
        return Ok(result);
    }
    
    [HttpGet("GetStudentsByTeacherId/{teacherId}")]
    public async Task<ActionResult<List<StudentDto>>> GetStudentsByTeacherId(Guid teacherId)
    {
        var result = await teacherService.GetStudentsByTeacherId(teacherId);
        return Ok(result);
    }
}