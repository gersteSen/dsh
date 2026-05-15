using API._Lesson.Dto;

namespace API._Lesson.Repository;

public interface ILessonRepository
{
    Task<Guid> CreateLessonAsync(CreateLessonDto createLessonDto, CancellationToken cancellationToken = default);
    Task UpdateLessonAsync(UpdateLessonDto updateLessonDto, Guid lessonId, CancellationToken cancellationToken = default);
    Task<List<LessonDto>> GetAllLessons(CancellationToken cancellationToken = default);
    Task<LessonDto> GetLessonById(Guid lessonId, CancellationToken cancellationToken = default);
}

