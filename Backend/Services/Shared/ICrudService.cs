using System;

namespace Backend.Services.Shared
{
    public interface ICrudService<T, ID>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(ID id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(ID id, T entity);
        public Task DeleteAsync(ID id);
    }
}
