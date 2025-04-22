using EducationSystem.Domain.Models;
using EducationSystem.Repository.Interface;
using EducationSystem.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EducationSystem.Repository.Implementation
{
    public class CourseUserRepository : ICourseUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<CourseUser> users;

        public CourseUserRepository(ApplicationDbContext _context)
        {
            context = _context;
            users = context.Set<CourseUser>();
        }

        // Метод за да ги добиеш сите корисници
        public List<CourseUser> GetAll()
        {
            return users
                .Include(u => u.MyCourses)
                .Include(u => u.UserQuizAttempts)
                .ToList();
        }

        // Метод за да добиеш корисник по Id
        public CourseUser GetCourseUser(string id)
        {
            return users
                .Include(u => u.MyCourses)
                .Include(u => u.UserQuizAttempts)
                .FirstOrDefault(u => u.Id == id);
        }

        // Метод за да додадеш нов корисник
        public void Add(CourseUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            users.Add(user);
            context.SaveChanges();
        }

        // Метод за да го ажурираш корисникот
        public void Update(CourseUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            users.Update(user);
            context.SaveChanges();
        }

        // Метод за да го избришеш корисникот
        public void Delete(string id)
        {
            var user = GetCourseUser(id);
            if (user != null)
            {
                users.Remove(user);
                context.SaveChanges();
            }
        }

        // Метод за да добиеш курсеви на корисникот
        public List<MyCourses> GetUserCourses(string userId)
        {
            return context.MyCourses
                          .Where(mc => mc.UserId == userId)
                          .Include(mc => mc.Course)
                          .ToList();
        }

        // Метод за да добиеш квиз обиди на корисникот
        public List<UserQuizAttempt> GetUserQuizAttempts(string userId)
        {
            return context.UserQuizAttempts
                          .Where(a => a.UserId == userId)
                          .Include(a => a.Quiz)
                          .ToList();
        }
    }
}
