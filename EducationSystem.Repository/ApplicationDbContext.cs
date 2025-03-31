using EducationSystem.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Web.Data;

public class ApplicationDbContext : IdentityDbContext<CourseUser>
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<MyCourses> MyCourses { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<UserQuizAttempt> UserQuizAttempts { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Author> Authors { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
