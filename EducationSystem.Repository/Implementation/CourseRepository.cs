using System;
using EducationSystem.Domain.Models;
using EducationSystem.Repository;
using Microsoft.EntityFrameworkCore;

public class CourseRepository : Repository<Course>, ICourseRepository
{
    private readonly ApplicationDbContext _context;

    public CourseRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Course>> GetAllCoursesWithAuthorAndModulesAsync()
    {
        return await _context.Courses
            .Include(c => c.Author)
            .Include(c => c.Modules)
            .ToListAsync();
    }
}
