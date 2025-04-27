using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EducationSystem.Domain.Models;
using EducationSystem.Repository.Interfaces;


namespace EducationSystem.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _context;
        private readonly DbSet<T> _entities;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetAsync(Guid? id)
        {
            if (id == null) return null;
            return await _entities.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T> InsertAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _entities.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
