using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Commons.Bases.Interfaces.Services
{
    public interface IBaseAppService<TDataResponse, TCommand> : IDisposable
    {
        Task<Result<TDataResponse>> SendCommand(TCommand dataRequest);
    }
}
