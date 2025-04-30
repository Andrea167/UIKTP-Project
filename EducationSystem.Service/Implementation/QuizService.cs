using EducationSystem.Domain.Models;
using EducationSystem.Repository.Interface;
using EducationSystem.Repository.Interfaces;
using EducationSystem.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EducationSystem.Service.Implementation
{
    public class QuizService : IQuizService
    {
        private readonly IRepository<Quiz> _quizRepository;

        public QuizService(IRepository<Quiz> quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<Quiz> GetQuizWithQuestionsAsync(Guid quizId)
        {
            var quiz = await _quizRepository.GetAsync(quizId);

            if (quiz != null)
            {
                // Here you may want to eager-load Questions + Answers manually
                // If needed in service level (because your generic repository doesn't auto-include)
            }

            return quiz;
        }
    }
}
