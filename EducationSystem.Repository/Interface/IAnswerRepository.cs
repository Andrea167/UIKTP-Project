using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationSystem.Domain.Models;

namespace EducationSystem.Repository.Interface
{
    public interface IAnswerRepository
    {
        List<Answer> GetAll();
        Answer GetAnswer(Guid id);
        void Add(Answer answer);
        void Update(Answer answer);
        void Delete(Guid id);

        // Опционално: метод за добивање на одговори по прашање
        List<Answer> GetAnswersByQuestionId(Guid questionId);
    }
}
