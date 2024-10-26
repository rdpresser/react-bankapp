using ReactBank.Domain.Core.Models;

namespace ReactBank.Domain.Interfaces.Services.Base
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<bool> Exists(Guid id);
        Task<TEntity> GetByIdAsync(Guid id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllNoTracking();
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
