using EducationSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using EducationSystem.Repository.Interfaces;

namespace EducationSystem.Service.Implementation
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<Course>> GetCoursesAsync()
        {
            return await _courseRepository.GetAllCoursesWithAuthorAndModulesAsync();
        }

        public async Task<Course> GetCourseByIdAsync(Guid id)
        {
            return await _courseRepository.GetAsync(id);
        }
    }

}
