using EducationSystem.Domain.Models;
using System;
using System.Collections.Generic;

namespace EducationSystem.Repository.Interface
{
    public interface ICourseUserRepository
    {
        List<CourseUser> GetAll();  // Добиј ги сите корисници
        CourseUser GetCourseUser(string id);  // Добиј корисник по Id
        void Add(CourseUser user);  // Додај нов корисник
        void Update(CourseUser user);  // Ажурирај корисник
        void Delete(string id);  // Избриши корисник

        // Дополнителни методи
        List<MyCourses> GetUserCourses(string userId);  // Добиј курсеви за конкретен корисник
        List<UserQuizAttempt> GetUserQuizAttempts(string userId);  // Добиј квиз обиди за корисникот
    }
}
