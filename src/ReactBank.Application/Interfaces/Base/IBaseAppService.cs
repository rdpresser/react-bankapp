namespace ReactBank.Application.Interfaces.Base
{
    //public interface IBaseAppService<TDataRequest, TDataResponse, TDataListResponse> : IDisposable
    public interface IBaseAppService<TDataRequest, TDataResponse> : IDisposable
        where TDataRequest : class, new()
        where TDataResponse : class, new()
    {
        Task<TDataResponse> CreateAsync(TDataRequest dataContract);
        Task<TDataResponse> UpdateAsync(TDataRequest dataContract);
        Task<TDataResponse> DeleteAsync(TDataRequest dataContract);
        Task<TDataResponse> GetByIdAsync(int id);
        Task<IEnumerable<TDataResponse>> GetAllAsync();
    }
}
