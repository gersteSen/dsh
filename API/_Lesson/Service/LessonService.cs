using API._Lesson.Dto;
using API._Lesson.Repository;

namespace API._Lesson.Service;

public class LessonService(ILessonRepository lessonRepository) : ILessonService
{
    public async Task<Guid> CreateLessonAsync(CreateLessonDto createLessonDto, CancellationToken cancellationToken = default)
    {
        return await lessonRepository.CreateLessonAsync(createLessonDto, cancellationToken);
    }

    public async Task UpdateLessonAsync(UpdateLessonDto updateLessonDto, Guid lessonId, CancellationToken cancellationToken = default)
    {
        await lessonRepository.UpdateLessonAsync(updateLessonDto, lessonId, cancellationToken);
    }

    public async Task<List<LessonDto>> GetAllLessons(CancellationToken cancellationToken = default)
    {
        return await lessonRepository.GetAllLessons(cancellationToken);
    }

    public async Task<LessonDto> GetLessonById(Guid lessonId, CancellationToken cancellationToken = default)
    {
        return await lessonRepository.GetLessonById(lessonId, cancellationToken);
    }
}

