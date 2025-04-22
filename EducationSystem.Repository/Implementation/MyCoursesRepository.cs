using EducationSystem.Domain.Models;
using EducationSystem.Repository.Interface;
using EducationSystem.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EducationSystem.Repository.Implementation
{
    public class MyCoursesRepository : IMyCoursesRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<MyCourses> myCourses;

        public MyCoursesRepository(ApplicationDbContext _context)
        {
            context = _context;
            myCourses = context.Set<MyCourses>();
        }

        public List<MyCourses> GetAll()
        {
            return myCourses
                .Include(mc => mc.Course)
                .Include(mc => mc.CourseUser)
                .ToList();
        }

        public MyCourses GetMyCourse(Guid id)
        {
            return myCourses
                .Include(mc => mc.Course)
                .Include(mc => mc.CourseUser)
                .FirstOrDefault(mc => mc.Id == id);
        }

        public void Add(MyCourses myCourse)
        {
            if (myCourse == null)
                throw new ArgumentNullException(nameof(myCourse));

            myCourses.Add(myCourse);
            context.SaveChanges();
        }

        public void Update(MyCourses myCourse)
        {
            if (myCourse == null)
                throw new ArgumentNullException(nameof(myCourse));

            myCourses.Update(myCourse);
            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var myCourse = GetMyCourse(id);
            if (myCourse != null)
            {
                myCourses.Remove(myCourse);
                context.SaveChanges();
            }
        }

        public List<MyCourses> GetCoursesByUserId(string userId)
        {
            return myCourses
                .Where(mc => mc.UserId == userId)
                .Include(mc => mc.Course)
                .Include(mc => mc.CourseUser)
                .ToList();
        }
    }
}
