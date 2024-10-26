//namespace ReactBank.Application.Services.Base
//{
//    public abstract class BaseAppDataContractCommandService<TDataRequest, TDataResponse, TCommand>
//        where TDataRequest : class
//        where TDataResponse : class
//        where TCommand : class
//    {
//        protected BaseAppDataContractCommandService()
//        {
//        }


//        public void Dispose()
//        {
//            GC.SuppressFinalize(this);
//        }


//        public async Task<TDataResponse> GetByIdAsync(Guid id)
//        {
//            return default;
//            var domainEntity = await BaseService.GetByIdAsync(id);
//            if (domainEntity == null)
//            {
//                return null;
//            }
//            return MapDomainEntityToDataResponse(domainEntity);
//        }

//        public async Task<TDataResponse> UpdateAsync(TDataRequest dataRequest)
//        {
//            return default;
//            var domainEntity = MapDataRequestToDomainEntity(dataRequest);
//            await BaseService.UpdateAsync(domainEntity);

//            return MapDomainEntityToDataResponse(domainEntity);
//        }

//        public abstract TCommand MapDataRequestToDomainEntity(TDataRequest dataContract);
//        public abstract TDataResponse MapDomainEntityToDataResponse(TCommand domainEntity);
//    }
//}
