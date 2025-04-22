using EducationSystem.Domain.Models;
using EducationSystem.Repository.Interface;
using EducationSystem.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EducationSystem.Repository.Implementation
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Question> questions;

        public QuestionRepository(ApplicationDbContext _context)
        {
            context = _context;
            questions = context.Set<Question>();
        }

        public List<Question> GetAll()
        {
            return questions
                .Include(q => q.Answers)
                .Include(q => q.Quiz)
                .ToList();
        }

        public Question GetQuestion(Guid id)
        {
            return questions
                .Include(q => q.Answers)
                .Include(q => q.Quiz)
                .FirstOrDefault(q => q.Id == id);
        }

        public void Add(Question question)
        {
            if (question == null)
                throw new ArgumentNullException(nameof(question));

            questions.Add(question);
            context.SaveChanges();
        }

        public void Update(Question question)
        {
            if (question == null)
                throw new ArgumentNullException(nameof(question));

            questions.Update(question);
            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var question = GetQuestion(id);
            if (question != null)
            {
                questions.Remove(question);
                context.SaveChanges();
            }
        }

        public List<Question> GetQuestionsByQuizId(Guid quizId)
        {
            return questions
                .Where(q => q.QuizId == quizId)
                .Include(q => q.Answers)
                .Include(q => q.Quiz)
                .ToList();
        }
    }
}
