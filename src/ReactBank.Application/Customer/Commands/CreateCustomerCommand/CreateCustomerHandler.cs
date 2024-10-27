using MediatR;
using ReactBank.Application.Commons.Bases.Interfaces.Validations;
using ReactBank.Application.Customer.DataContracts;
using ReactBank.Domain.Core.Notifications;
using ReactBank.Domain.Interfaces.Repositores;
using ReactBank.Domain.Interfaces.Services;

namespace ReactBank.Application.Customer.Commands.CreateCustomerCommand
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Result<CustomerDataResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerService _customerService;
        private readonly IBaseValidation<CreateCustomerCommand> _validator;

        public CreateCustomerHandler(IUnitOfWork unitOfWork, ICustomerService customerService, IBaseValidation<CreateCustomerCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _customerService = customerService;
            _validator = validator;
        }

        public async Task<Result<CustomerDataResponse>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _validator.IsValidAsync(request);
                if (!result.IsValid)
                {
                    return Result<CustomerDataResponse>.Failure(result.ToDictionary());
                }

                var customer = new Domain.Models.Customer
                {
                    Name = request.Name,
                    Email = request.Email,
                    Phone = request.Phone,
                    StreetAddress = request.StreetAddress,
                    City = request.City,
                    State = request.State,
                    ZipCode = request.ZipCode,
                    DateOfBirth = request.DateOfBirth,
                    IdentityDocument = request.IdentityDocument
                };

                await _customerService.AddAsync(customer);
                await _unitOfWork.CommitAsync(cancellationToken);

                return Result<CustomerDataResponse>.Success(new CustomerDataResponse(
                    Id: customer.Id,
                    Name: customer.Name,
                    Email: customer.Email,
                    Phone: customer.Phone,
                    StreetAddress: customer.StreetAddress,
                    City: customer.City,
                    State: customer.State,
                    ZipCode: customer.ZipCode,
                    DateOfBirth: customer.DateOfBirth.ToString("MMMM dd, yyyy"),
                    IdentityDocument: customer.IdentityDocument
                ));
            }
            catch (Exception ex)
            {
                return Result<CustomerDataResponse>.Failure(new Dictionary<string, string[]> { { "CreateCustomerCommand", [ex.Message] } });
            }
        }
    }
}
