using MediatR;
using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Commons.Bases.Services
{
    public abstract class BaseAppService<TDataRequest, TDataResponse, TCommand> //: IBaseAppService<TDataRequest, TDataResponse, TCommand>
            where TDataRequest : class
            where TDataResponse : class
            where TCommand : class
    {
        public ISender Sender { get; }

        protected BaseAppService(ISender sender)
        {
            Sender = sender;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public abstract Result<TDataResponse> MapDataRequestToCommand(TDataRequest dataRequest);
    }
}
