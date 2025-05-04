using System.Reflection.Emit;
using EducationSystem.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Repository
{
    public class ApplicationDbContext : IdentityDbContext<CourseUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseUser> CourseUsers { get; set; }

        public DbSet<MyCourses> MyCourses { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<UserQuizAttempt> UserQuizAttempts { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<CourseModule> CourseModules { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var author1Id = Guid.NewGuid();
            var author2Id = Guid.NewGuid();
            var author3Id = Guid.NewGuid();

            var authorId = Guid.NewGuid();
            modelBuilder.Entity<Author>().HasData(
               new Author { Id = author1Id, Name = "Dr. Alan Turing", Bio = "Mathematician and logician." },
               new Author { Id = author2Id, Name = "Ada Lovelace", Bio = "Pioneer of computing and OOP." },
               new Author { Id = author3Id, Name = "Dennis Ritchie", Bio = "Created the C language and OS theory." }
            );

            var course1Id = Guid.NewGuid();
            var course2Id = Guid.NewGuid();
            var course3Id = Guid.NewGuid();

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = course1Id, Title = "Calculus", Description = "Learn Calculus from scratch", AuthorId = author1Id },
                new Course { Id = course2Id, Title = "Object Oriented Programming", Description = "Understand OOP concepts", AuthorId = author2Id },
                new Course { Id = course3Id, Title = "Operating System", Description = "Introduction to OS principles", AuthorId = author3Id }
            );

            modelBuilder.Entity<CourseModule>().HasData(
                new CourseModule { Id = Guid.NewGuid(), Title = "Limits", CourseId = course1Id },
                new CourseModule { Id = Guid.NewGuid(), Title = "Integrals", CourseId = course1Id },
                new CourseModule { Id = Guid.NewGuid(), Title = "Graph and functions", CourseId = course1Id }
            );
            modelBuilder.Entity<CourseModule>().HasData(
            new CourseModule { Id = Guid.NewGuid(), Title = "Classes and Objects", CourseId = course2Id },
            new CourseModule { Id = Guid.NewGuid(), Title = "Inheritance and Polymorphism", CourseId = course2Id },
            new CourseModule { Id = Guid.NewGuid(), Title = "Abstraction and Interfaces", CourseId = course2Id }
            );
            modelBuilder.Entity<CourseModule>().HasData(
            new CourseModule { Id = Guid.NewGuid(), Title = "Processes and Threads", CourseId = course3Id },
            new CourseModule { Id = Guid.NewGuid(), Title = "Memory Management", CourseId = course3Id },
            new CourseModule { Id = Guid.NewGuid(), Title = "File Systems", CourseId = course3Id }
            );
        }
    }
}
