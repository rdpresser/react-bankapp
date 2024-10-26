using ReactBank.Domain.Core.Models;
using ReactBank.Domain.Interfaces.Repositores.Base;
using ReactBank.Domain.Interfaces.Services.Base;

namespace ReactBank.Domain.Services.Base
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        protected IBaseRepository<TEntity> BaseRepository { get; }

        protected BaseService(IBaseRepository<TEntity> baseRepository)
        {
            BaseRepository = baseRepository ?? throw new ArgumentNullException(nameof(baseRepository), $"{nameof(baseRepository)} could not be null");
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }
            return await BaseRepository.AddAsync(entity);
        }

        public Task<bool> Exists(Guid id)
        {
            return BaseRepository.Exists(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return BaseRepository.GetAll();
        }

        public IQueryable<TEntity> GetAllNoTracking()
        {
            return BaseRepository.GetAllNoTracking();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await BaseRepository.GetByIdAsync(id);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return await BaseRepository.UpdateAsync(entity);
        }
    }
}
