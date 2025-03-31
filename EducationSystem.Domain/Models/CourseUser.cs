using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EducationSystem.Domain.Models
{
    public class CourseUser:IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public virtual ICollection<MyCourses> MyCourses { get; set; } = new List<MyCourses>();
        public virtual ICollection<UserQuizAttempt> UserQuizAttempts { get; set; } = new List<UserQuizAttempt>();
    }
}
