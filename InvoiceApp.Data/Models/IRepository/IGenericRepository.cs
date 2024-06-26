﻿
using System.Linq.Expressions;

namespace InvoiceApp.Data.Models.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(object id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IEnumerable<T>> GetAllIncludingAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByIdIncludingAsync<TKey>(TKey id, params Expression<Func<T, object>>[] includeProperties);
        Task DeleteRangeAsync(IEnumerable<T> entities);
    }
}
