using EducationSystem.Domain.Models;
using EducationSystem.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationSystem.Repository.Implementation
{
    public class UserQuizAttemptRepository : Repository<UserQuizAttempt>, IUserQuizAttemptRepository
    {
        public UserQuizAttemptRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<UserQuizAttempt>> GetAttemptsByUserIdAsync(string userId)
        {
            return await _context.Set<UserQuizAttempt>()
                .Include(x => x.Quiz)
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task<UserQuizAttempt> SubmitQuizAsync(string userId, Guid quizId, Dictionary<Guid, Guid> questionAnswerMap)
        {
            var questions = await _context.Set<Question>()
                .Include(q => q.Answers)
                .Where(q => q.QuizId == quizId)
                .ToListAsync();

            int score = 0;
            foreach (var question in questions)
            {
                if (questionAnswerMap.TryGetValue(question.Id, out var selectedAnswerId))
                {
                    var correctAnswer = question.Answers.FirstOrDefault(a => a.IsCorrect);
                    if (correctAnswer != null && correctAnswer.Id == selectedAnswerId)
                    {
                        score++;
                    }
                }
            }

            var attempt = new UserQuizAttempt
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                QuizId = quizId,
                Score = score,
                AttemptDate = DateTime.UtcNow
            };

            await InsertAsync(attempt);

            return attempt;
        }
    }
}
