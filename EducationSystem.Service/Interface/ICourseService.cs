using EducationSystem.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICourseService
{
    Task<IEnumerable<Course>> GetCoursesAsync();
    Task<Course> GetCourseByIdAsync(Guid id);
}

