using EducationSystem.Domain.Models;
using System;
using System.Collections.Generic;

namespace EducationSystem.Repository.Interface
{
    public interface IUserQuizAttemptRepository
    {
        List<UserQuizAttempt> GetAll();
        UserQuizAttempt GetAttempt(Guid id);
        void Add(UserQuizAttempt userQuizAttempt);
        void Update(UserQuizAttempt userQuizAttempt);
        void Delete(Guid id);
        List<UserQuizAttempt> GetAttemptsByUserId(string userId);  // Добиј сите обиди за одреден корисник
    }
}
