using ReactBank.Application.Interfaces.Base;
using ReactBank.Domain.Core.Models;
using ReactBank.Domain.Interfaces.Repositores;
using ReactBank.Domain.Interfaces.Services.Base;

namespace ReactBank.Application.Services.Base
{
    public abstract class BaseAppDataContractDomainService<TDataRequest, TDataResponse, TDomainEntity>
        : BaseAppService, IBaseAppService<TDataRequest, TDataResponse>
        where TDataRequest : class, new()
        where TDataResponse : class, new()
        where TDomainEntity : BaseEntity, new()
    {
        protected IBaseService<TDomainEntity> BaseService { get; }

        protected BaseAppDataContractDomainService(IUnitOfWork unitOfWork, IBaseService<TDomainEntity> baseService)
            : base(unitOfWork)
        {
            BaseService = baseService ?? throw new ArgumentNullException(nameof(baseService), $"{nameof(baseService)} could not be null");
        }

        public async Task<TDataResponse> CreateAsync(TDataRequest dataRequest)
        {
            var domainEntity = MapDataRequestToDomainEntity(dataRequest);
            domainEntity.Id = Guid.NewGuid();
            domainEntity = await BaseService.AddAsync(domainEntity);
            await CommitAsync();

            return MapDomainEntityToDataResponse(domainEntity);
        }

        public Task<TDataResponse> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public abstract Task<IEnumerable<TDataResponse>> GetAllAsync();

        public async Task<TDataResponse> GetByIdAsync(Guid id)
        {
            var domainEntity = await BaseService.GetByIdAsync(id);
            if (domainEntity == null)
            {
                return null;
            }
            return MapDomainEntityToDataResponse(domainEntity);
        }

        public Task<TDataResponse> UpdateAsync(TDataRequest dataRequest)
        {
            throw new NotImplementedException();
        }

        public abstract TDomainEntity MapDataRequestToDomainEntity(TDataRequest dataContract);
        public abstract TDataResponse MapDomainEntityToDataResponse(TDomainEntity domainEntity);
    }
}
