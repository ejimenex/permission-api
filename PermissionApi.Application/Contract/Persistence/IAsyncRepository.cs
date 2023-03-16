﻿namespace PermissionApi.Application.Contract.Persistence
{

    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int Id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int Id);
    }
}
