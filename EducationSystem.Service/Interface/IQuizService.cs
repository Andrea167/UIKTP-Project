using EducationSystem.Domain.Models;
using System;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationSystem.Service.Interface
{
    public interface IQuizService
    {
        Task<Quiz> GetQuizWithQuestionsAsync(Guid quizId);
    }
}
