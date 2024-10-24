using ReactBank.Domain.Interfaces.Repositores;
using ReactBank.Infra.Data.Context;

namespace ReactBank.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            var rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
