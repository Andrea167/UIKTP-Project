using EducationSystem.Domain.Models;
using EducationSystem.Repository.Interface;
using EducationSystem.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EducationSystem.Repository.Implementation
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Answer> answers;

        public AnswerRepository(ApplicationDbContext _context)
        {
            context = _context;
            answers = context.Set<Answer>();
        }

        public List<Answer> GetAll()
        {
            return answers.Include(a => a.Question).ToList();
        }

        public Answer GetAnswer(Guid id)
        {
            return answers.Include(a => a.Question).FirstOrDefault(a => a.Id == id);
        }

        public void Add(Answer answer)
        {
            if (answer == null)
                throw new ArgumentNullException(nameof(answer));

            answers.Add(answer);
            context.SaveChanges();
        }

        public void Update(Answer answer)
        {
            if (answer == null)
                throw new ArgumentNullException(nameof(answer));

            answers.Update(answer);
            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var answer = GetAnswer(id);
            if (answer != null)
            {
                answers.Remove(answer);
                context.SaveChanges();
            }
        }

        public List<Answer> GetAnswersByQuestionId(Guid questionId)
        {
            return answers.Where(a => a.QuestionId == questionId).ToList();
        }
    }
}
