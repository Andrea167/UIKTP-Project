using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EducationSystem.Domain.Models;

namespace EducationSystem.Repository.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(Guid? id);
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
