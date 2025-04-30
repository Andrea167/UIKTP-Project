using System;
using EducationSystem.Domain.Models;
using EducationSystem.Repository;
using Microsoft.EntityFrameworkCore;

public class CourseRepository : ICourseRepository
{
    private readonly ApplicationDbContext _context;

    public CourseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Course>> GetAllCoursesAsync()
    {
        return await _context.Courses.Include(c => c.Author).ToListAsync();
    }

    public async Task<Course> GetCourseByIdAsync(Guid id)
    {
        return await _context.Courses.Include(c => c.Author).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddCourseAsync(Course course)
    {
        await _context.Courses.AddAsync(course);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCourseAsync(Course course)
    {
        _context.Courses.Update(course);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCourseAsync(Guid id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course != null)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }
    }
}
