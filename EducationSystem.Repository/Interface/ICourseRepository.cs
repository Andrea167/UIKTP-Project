using EducationSystem.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICourseRepository
{
    Task<IEnumerable<Course>> GetAllCoursesAsync();
    Task<Course> GetCourseByIdAsync(Guid id);
    Task AddCourseAsync(Course course);
    Task UpdateCourseAsync(Course course);
    Task DeleteCourseAsync(Guid id);
}
