using MediatR;
using ReactBank.Application.Loan.Abstractions;
using ReactBank.Application.Loan.Commands.CreateLoanCommand;
using ReactBank.Application.Loan.DataContracts;
using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Services
{
    public class LoanAppService : ILoanAppService
    {
        private readonly IMediator _mediator;

        public LoanAppService(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator), $"{nameof(mediator)} could not be null");
        }

        public async Task<Result<LoanDataResponse>> CreateLoanAsync(LoanDataRequest loanDataRequest)
        {
            return await _mediator.Send(MapDataRequestToCommand(loanDataRequest));
        }

        public Task<Result<IEnumerable<LoanDataResponse>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<LoanDataResponse>> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public CreateLoanCommand MapDataRequestToCommand(LoanDataRequest loanDataRequest)
        {
            return new CreateLoanCommand(
                loanDataRequest.Amount,
                loanDataRequest.InterestRate,
                loanDataRequest.StartDate,
                loanDataRequest.EndDate,
                loanDataRequest.AccountId
            );
        }

        //public override async Task<IEnumerable<LoanDataResponse>> GetAllAsync()
        //{
        //    var list = await BaseService.GetAllNoTracking()
        //        .OrderBy(x => x.StartDate)
        //        .ToListAsync();
        //    return list.Select(x => MapDomainEntityToDataResponse(x));
        //}

        //public override Loan MapDataRequestToDomainEntity(LoanDataRequest dataContract)
        //{
        //    return new Loan
        //    {
        //        Amount = dataContract.Amount,
        //        AccountId = dataContract.AccountId,
        //        StartDate = dataContract.StartDate,
        //        EndDate = dataContract.EndDate,
        //        InterestRate = dataContract.InterestRate
        //    };
        //}

        //public override LoanDataResponse MapDomainEntityToDataResponse(Loan domainEntity)
        //{
        //    return new LoanDataResponse
        //    {
        //        Amount = domainEntity.Amount,
        //        AccountId = domainEntity.AccountId,
        //        StartDate = domainEntity.StartDate,
        //        EndDate = domainEntity.EndDate,
        //        InterestRate = domainEntity.InterestRate,
        //        Id = domainEntity.Id
        //    };
        //}
    }
}
