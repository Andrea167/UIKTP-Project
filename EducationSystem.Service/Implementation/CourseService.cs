using EducationSystem.Domain.Models;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _repository;

    public CourseService(ICourseRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Course>> GetCoursesAsync()
    {
        return await _repository.GetAllCoursesAsync();
    }

    public async Task<Course> GetCourseByIdAsync(Guid id)
    {
        return await _repository.GetCourseByIdAsync(id);
    }
}
