using EducationSystem.Domain.Models;
using EducationSystem.Repository.Interface;
using EducationSystem.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EducationSystem.Repository.Implementation
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Author> authors;

        public AuthorRepository(ApplicationDbContext _context)
        {
            context = _context;
            authors = context.Set<Author>();
        }

        public List<Author> GetAll()
        {
            return authors.Include(a => a.Courses).ToList();
        }

        public Author GetAuthor(Guid id)
        {
            return authors.Include(a => a.Courses).FirstOrDefault(a => a.Id == id);
        }

        public void Add(Author author)
        {
            if (author == null)
                throw new ArgumentNullException(nameof(author));

            authors.Add(author);
            context.SaveChanges();
        }

        public void Update(Author author)
        {
            if (author == null)
                throw new ArgumentNullException(nameof(author));

            authors.Update(author);
            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var author = GetAuthor(id);
            if (author != null)
            {
                authors.Remove(author);
                context.SaveChanges();
            }
        }

        public List<Course> GetCoursesByAuthor(Guid authorId)
        {
            return context.Courses
                          .Where(c => c.AuthorId == authorId)
                          .ToList();
        }
    }
}
