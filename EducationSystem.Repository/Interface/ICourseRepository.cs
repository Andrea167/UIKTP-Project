using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationSystem.Domain.Models;

namespace EducationSystem.Repository.Interface
{
    public interface ICourseRepository
    {
        List<Course> GetAll();
        Course GetCourse(Guid id);
        void Add(Course course);
        void Update(Course course);
        void Delete(Guid id);

        // Дополнително
        List<Course> GetCoursesByAuthor(Guid authorId);
    }
}
