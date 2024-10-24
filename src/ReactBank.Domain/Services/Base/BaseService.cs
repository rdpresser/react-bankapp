using ReactBank.Domain.Core.Models;
using ReactBank.Domain.Interfaces.Repositores.Base;
using ReactBank.Domain.Interfaces.Services.Base;

namespace ReactBank.Domain.Services.Base
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        protected BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository ?? throw new ArgumentNullException(nameof(baseRepository), $"{nameof(baseRepository)} could not be null");
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return await _baseRepository.AddAsync(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public IQueryable<TEntity> GetAllNoTracking()
        {
            return _baseRepository.GetAllNoTracking();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return await _baseRepository.UpdateAsync(entity);
        }
    }
}
