using API._Lesson.Dto;
using API._Lesson.Service;
using Microsoft.AspNetCore.Mvc;

namespace API._Lesson.Controller;

[ApiController]
[Route("api/v1/[controller]")]
public class LessonController(ILessonService lessonService) : ControllerBase
{
    [HttpPost("CreateLesson")]
    public async Task<ActionResult<Guid>> CreateLesson([FromBody] CreateLessonDto createLessonDto, CancellationToken cancellationToken)
    {
        var lessonId = await lessonService.CreateLessonAsync(createLessonDto, cancellationToken);
        return Ok(lessonId);
    }

    [HttpPut("UpdateLesson/{lessonId}")]
    public async Task<ActionResult> UpdateLesson(Guid lessonId, [FromBody] UpdateLessonDto updateLessonDto, CancellationToken cancellationToken)
    {
        await lessonService.UpdateLessonAsync(updateLessonDto, lessonId, cancellationToken);
        return NoContent();
    }

    [HttpGet("GetAllLessons")]
    public async Task<ActionResult<List<LessonDto>>> GetAllLessons(CancellationToken cancellationToken)
    {
        var result = await lessonService.GetAllLessons(cancellationToken);
        return Ok(result);
    }

    [HttpGet("GetLessonById/{lessonId}")]
    public async Task<ActionResult<LessonDto>> GetLessonById(Guid lessonId, CancellationToken cancellationToken)
    {
        var result = await lessonService.GetLessonById(lessonId, cancellationToken);
        return Ok(result);
    }
}

