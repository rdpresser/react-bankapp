using Microsoft.EntityFrameworkCore;
using ReactBank.Domain.Core.Models;
using ReactBank.Domain.Interfaces.Repositores.Base;
using ReactBank.Infra.Data.Context;

namespace ReactBank.Infra.Data.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected ApplicationDbContext Db { get; }
        protected DbSet<TEntity> DbSet { get; }

        public BaseRepository(ApplicationDbContext context)
        {
            Db = context;
            DbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            return entity;
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual IQueryable<TEntity> GetAllNoTracking()
        {
            return DbSet;
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }
    }
}
