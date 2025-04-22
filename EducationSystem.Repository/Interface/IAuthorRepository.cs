using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationSystem.Domain.Models;

namespace EducationSystem.Repository.Interface
{
    public interface IAuthorRepository
    {
        List<Author> GetAll();
        Author GetAuthor(Guid id);
        void Add(Author author);
        void Update(Author author);
        void Delete(Guid id);

        // Опционално: автор со курсеви
        List<Course> GetCoursesByAuthor(Guid authorId);
    }
}
