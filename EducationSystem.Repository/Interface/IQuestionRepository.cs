using EducationSystem.Domain.Models;
using System;
using System.Collections.Generic;

namespace EducationSystem.Repository.Interface
{
    public interface IQuestionRepository
    {
        List<Question> GetAll();
        Question GetQuestion(Guid id);
        void Add(Question question);
        void Update(Question question);
        void Delete(Guid id);
        List<Question> GetQuestionsByQuizId(Guid quizId);  // Добиј сите прашања од одреден квиз
    }
}
