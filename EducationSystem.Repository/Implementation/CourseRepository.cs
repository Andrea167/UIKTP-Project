using EducationSystem.Domain.Models;
using EducationSystem.Repository.Interface;
using EducationSystem.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EducationSystem.Repository.Implementation
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Course> courses;

        public CourseRepository(ApplicationDbContext _context)
        {
            context = _context;
            courses = context.Set<Course>();
        }

        public List<Course> GetAll()
        {
            return courses
                .Include(c => c.Author)
                .Include(c => c.Quizzes)
                .Include(c => c.MyCourses)
                .ToList();
        }

        public Course GetCourse(Guid id)
        {
            return courses
                .Include(c => c.Author)
                .Include(c => c.Quizzes)
                .Include(c => c.MyCourses)
                .FirstOrDefault(c => c.Id == id);
        }

        public void Add(Course course)
        {
            if (course == null)
                throw new ArgumentNullException(nameof(course));

            courses.Add(course);
            context.SaveChanges();
        }

        public void Update(Course course)
        {
            if (course == null)
                throw new ArgumentNullException(nameof(course));

            courses.Update(course);
            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var course = GetCourse(id);
            if (course != null)
            {
                courses.Remove(course);
                context.SaveChanges();
            }
        }

        public List<Course> GetCoursesByAuthor(Guid authorId)
        {
            return courses
                .Where(c => c.AuthorId == authorId)
                .Include(c => c.Quizzes)
                .ToList();
        }
    }
}
