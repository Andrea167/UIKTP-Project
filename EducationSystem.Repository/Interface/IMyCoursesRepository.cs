using EducationSystem.Domain.Models;
using System;
using System.Collections.Generic;

namespace EducationSystem.Repository.Interface
{
    public interface IMyCoursesRepository
    {
        List<MyCourses> GetAll();
        MyCourses GetMyCourse(Guid id);
        void Add(MyCourses myCourse);
        void Update(MyCourses myCourse);
        void Delete(Guid id);
        List<MyCourses> GetCoursesByUserId(string userId);  // Добиј сите курсеви на корисникот
    }
}
