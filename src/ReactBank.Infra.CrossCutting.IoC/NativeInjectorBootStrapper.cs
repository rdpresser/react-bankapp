using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReactBank.Application.Account.Abstractions;
using ReactBank.Application.Account.Commands.CreateAccountCommand;
using ReactBank.Application.Commons.Bases.Interfaces.Validations;
using ReactBank.Application.Operation.Abstractions;
using ReactBank.Domain.Interfaces.Repositores;
using ReactBank.Domain.Interfaces.Repositores.Base;
using ReactBank.Domain.Interfaces.Services;
using ReactBank.Domain.Services;
using ReactBank.Infra.Data.Context;
using ReactBank.Infra.Data.Repositories;
using ReactBank.Infra.Data.Repositories.Base;
using ReactBank.Infra.Data.UoW;

namespace ReactBank.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            RegisterInfra(services, configuration);
            RegisterDomain(services);
            RegisterApplication(services);

            return services;
        }

        private static void RegisterInfra(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
        }

        private static void RegisterDomain(IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IOperationService, OperationService>();
        }

        private static void RegisterApplication(IServiceCollection services)
        {
            services.AddScoped<IAccountAppService, AccountAppService>();
            services.AddScoped<IBaseValidation<CreateAccountCommand>, CreateAccountValidator>();
            //services.AddScoped<ICustomerAppService, CustomerAppService>();
            //services.AddScoped<ILoanAppService, LoanAppService>();
            //services.AddScoped<ITransactionAppService, TransactionAppService>();
            services.AddScoped<IOperationAppService, OperationAppService>();
        }
    }
}
