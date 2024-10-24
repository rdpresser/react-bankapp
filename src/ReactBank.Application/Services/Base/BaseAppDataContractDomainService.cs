using ReactBank.Application.Interfaces.Base;
using ReactBank.Domain.Core.Models;
using ReactBank.Domain.Interfaces.Repositores;
using ReactBank.Domain.Interfaces.Services.Base;

namespace ReactBank.Application.Services.Base
{
    public abstract class BaseAppDataContractDomainService<TDataRequest, TDataResponse, TDomainEntity> : BaseAppService, IBaseAppService<TDataRequest, TDataResponse>
        where TDataRequest : class, new()
        where TDataResponse : class, new()
        where TDomainEntity : BaseEntity, new()
    {
        private readonly IBaseService<TDomainEntity> _baseService;

        protected BaseAppDataContractDomainService(IUnitOfWork unitOfWork, IBaseService<TDomainEntity> baseService)
            : base(unitOfWork)
        {
            _baseService = baseService ?? throw new ArgumentNullException(nameof(baseService), $"{nameof(baseService)} could not be null");
        }

        public async Task<TDataResponse> CreateAsync(TDataRequest dataRequest)
        {
            var domainEntity = MapDataRequestToDomainEntity(dataRequest);
            domainEntity = await _baseService.AddAsync(domainEntity);
            await CommitAsync();

            return MapDomainEntityToDataResponse(domainEntity);
        }

        public Task<TDataResponse> DeleteAsync(TDataRequest dataRequest)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Task<IEnumerable<TDataResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TDataResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TDataResponse> UpdateAsync(TDataRequest dataRequest)
        {
            throw new NotImplementedException();
        }

        public abstract TDomainEntity MapDataRequestToDomainEntity(TDataRequest dataContract);
        public abstract TDataResponse MapDomainEntityToDataResponse(TDomainEntity domainEntity);
    }
}
