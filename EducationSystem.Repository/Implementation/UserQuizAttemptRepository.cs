using EducationSystem.Domain.Models;
using EducationSystem.Repository.Interface;
using EducationSystem.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EducationSystem.Repository.Implementation
{
    public class UserQuizAttemptRepository : IUserQuizAttemptRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<UserQuizAttempt> userQuizAttempts;

        public UserQuizAttemptRepository(ApplicationDbContext _context)
        {
            context = _context;
            userQuizAttempts = context.Set<UserQuizAttempt>();
        }

        public List<UserQuizAttempt> GetAll()
        {
            return userQuizAttempts
                .Include(u => u.CourseUser)
                .Include(u => u.Quiz)
                .ToList();
        }

        public UserQuizAttempt GetAttempt(Guid id)
        {
            return userQuizAttempts
                .Include(u => u.CourseUser)
                .Include(u => u.Quiz)
                .FirstOrDefault(u => u.Id == id);
        }

        public void Add(UserQuizAttempt userQuizAttempt)
        {
            if (userQuizAttempt == null)
                throw new ArgumentNullException(nameof(userQuizAttempt));

            userQuizAttempts.Add(userQuizAttempt);
            context.SaveChanges();
        }

        public void Update(UserQuizAttempt userQuizAttempt)
        {
            if (userQuizAttempt == null)
                throw new ArgumentNullException(nameof(userQuizAttempt));

            userQuizAttempts.Update(userQuizAttempt);
            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var attempt = GetAttempt(id);
            if (attempt != null)
            {
                userQuizAttempts.Remove(attempt);
                context.SaveChanges();
            }
        }

        public List<UserQuizAttempt> GetAttemptsByUserId(string userId)
        {
            return userQuizAttempts
                .Where(u => u.UserId == userId)
                .Include(u => u.CourseUser)
                .Include(u => u.Quiz)
                .ToList();
        }
    }
}
