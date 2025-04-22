using EducationSystem.Domain.Models;
using System;
using System.Collections.Generic;

namespace EducationSystem.Repository.Interface
{
    public interface IQuizRepository
    {
        List<Quiz> GetAll();
        Quiz GetQuiz(Guid id);
        void Add(Quiz quiz);
        void Update(Quiz quiz);
        void Delete(Guid id);
        List<Quiz> GetQuizzesByCourseId(Guid courseId);  // Добиј сите квизови за одреден курс
    }
}
