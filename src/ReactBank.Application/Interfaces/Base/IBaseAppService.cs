namespace ReactBank.Application.Interfaces.Base
{
    //public interface IBaseAppService<TDataRequest, TDataResponse, TDataListResponse> : IDisposable
    public interface IBaseAppService<TDataRequest, TDataResponse> : IDisposable
        where TDataRequest : class, new()
        where TDataResponse : class, new()
    {
        Task<TDataResponse> CreateAsync(TDataRequest dataContract);
        Task<TDataResponse> UpdateAsync(TDataRequest dataContract);
        Task<TDataResponse> DeleteAsync(Guid id);
        Task<TDataResponse> GetByIdAsync(Guid id);
        Task<IEnumerable<TDataResponse>> GetAllAsync();
    }
}
