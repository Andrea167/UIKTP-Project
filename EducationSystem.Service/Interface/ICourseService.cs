using EducationSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationSystem.Service.Interface
{
    public interface ICourseService
    {
        Task<List<Course>> GetAllCoursesAsync();
        Task<Course> GetCourseByIdAsync(Guid courseId);
        Task<List<Course>> GetCoursesFilteredAsync(string searchTerm);
    }
}
