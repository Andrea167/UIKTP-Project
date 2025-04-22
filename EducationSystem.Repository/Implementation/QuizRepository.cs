using EducationSystem.Domain.Models;
using EducationSystem.Repository.Interface;
using EducationSystem.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EducationSystem.Repository.Implementation
{
    public class QuizRepository : IQuizRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Quiz> quizzes;

        public QuizRepository(ApplicationDbContext _context)
        {
            context = _context;
            quizzes = context.Set<Quiz>();
        }

        public List<Quiz> GetAll()
        {
            return quizzes
                .Include(q => q.Course)
                .Include(q => q.Questions)
                .ToList();
        }

        public Quiz GetQuiz(Guid id)
        {
            return quizzes
                .Include(q => q.Course)
                .Include(q => q.Questions)
                .FirstOrDefault(q => q.Id == id);
        }

        public void Add(Quiz quiz)
        {
            if (quiz == null)
                throw new ArgumentNullException(nameof(quiz));

            quizzes.Add(quiz);
            context.SaveChanges();
        }

        public void Update(Quiz quiz)
        {
            if (quiz == null)
                throw new ArgumentNullException(nameof(quiz));

            quizzes.Update(quiz);
            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var quiz = GetQuiz(id);
            if (quiz != null)
            {
                quizzes.Remove(quiz);
                context.SaveChanges();
            }
        }

        public List<Quiz> GetQuizzesByCourseId(Guid courseId)
        {
            return quizzes
                .Where(q => q.CourseId == courseId)
                .Include(q => q.Course)
                .Include(q => q.Questions)
                .ToList();
        }
    }
}
