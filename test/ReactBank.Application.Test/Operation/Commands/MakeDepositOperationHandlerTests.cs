using FluentValidation;
using NSubstitute;
using ReactBank.Application.Commons.Bases.Interfaces.Validations;
using ReactBank.Application.Operation.Abstractions;
using ReactBank.Application.Operation.Commands.MakeDepositOperationCommand;
using ReactBank.Application.Operation.DataContracts;
using ReactBank.Domain.Core.Notifications;
using ReactBank.Domain.Interfaces.Repositores;
using ReactBank.Domain.Interfaces.Services;

namespace ReactBank.Application.Test.Operation.Commands
{
    public class MakeDepositOperationHandlerTests
    {
        [Fact]
        public async Task MakeDepositOperationHandler_WhenCalledWithValidData_ShouldReturnSuccessResult()
        {
            // Arrange
            var accountId = Guid.NewGuid();
            var makeDepositOperationDataRequest = new MakeDepositOperationDataRequest
            {
                AccountId = accountId,
                Amount = 100
            };

            var operationAppServiceMock = Substitute.For<IOperationAppService>();
            var unitOfWorkMock = Substitute.For<IUnitOfWork>();
            var accountServiceMock = Substitute.For<IAccountService>();
            var transactionServiceMock = Substitute.For<ITransactionService>();
            var validatorMock = Substitute.For<IBaseValidation<MakeDepositOperationCommand>>();

            var dataResponse = new DefaultOperationDataResponse(accountId);

            operationAppServiceMock.MakeDeposit(Arg.Any<MakeDepositOperationDataRequest>())
                .Returns(Task.FromResult(Result<DefaultOperationDataResponse>.Success(dataResponse)));

            var command = new MakeDepositOperationCommand(makeDepositOperationDataRequest.AccountId, makeDepositOperationDataRequest.Amount);

            var context = new ValidationContext<MakeDepositOperationCommand>(command);
            //(validatorMock as MakeDepositOperationValidator).ValidateAsync(context);
            var validatorMockInstance = Substitute.For<MakeDepositOperationValidator>();

            var validationResult = await validatorMockInstance.ValidateAsync(context);
            validatorMock.IsValidAsync(command).Returns(validationResult);

            var handler = new MakeDepositOperationHandler(unitOfWorkMock, accountServiceMock, transactionServiceMock, validatorMock);

            // Act

            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
        }

    }
}
