using EducationSystem.Domain.Models;
using EducationSystem.Repository.Interface;
using EducationSystem.Service.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationSystem.Service.Implementation
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _courseRepository;

        public CourseService(IRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            return await _courseRepository.GetAllAsync();
        }

        public async Task<Course> GetCourseByIdAsync(Guid courseId)
        {
            return await _courseRepository.GetAsync(courseId);
        }
        public async Task<List<Course>> GetCoursesFilteredAsync(string searchTerm)
        {
            var courses = await _courseRepository.GetAllAsync();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                courses = courses.Where(c => c.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return courses;
        }

    }
}
