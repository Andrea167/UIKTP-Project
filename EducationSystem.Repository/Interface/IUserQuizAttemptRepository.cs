using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystem.Repository.Interface
{
    public interface IUserQuizAttemptRepository : IRepository<UserQuizAttempt>
    {
        Task<List<UserQuizAttempt>> GetAttemptsByUserIdAsync(string userId);
        Task<UserQuizAttempt> SubmitQuizAsync(string userId, Guid quizId, Dictionary<Guid, Guid> questionAnswerMap);
    }
}
