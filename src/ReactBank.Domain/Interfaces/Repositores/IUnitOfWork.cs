namespace ReactBank.Domain.Interfaces.Repositores
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsync();
    }
}
