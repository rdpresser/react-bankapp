using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReactBank.Domain.Interfaces.Repositores;
using ReactBank.Domain.Interfaces.Repositores.Base;
using ReactBank.Domain.Interfaces.Services;
using ReactBank.Domain.Services;
using ReactBank.Infra.Data.Context;
using ReactBank.Infra.Data.Repositories;
using ReactBank.Infra.Data.Repositories.Base;

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
        }

        private static void RegisterApplication(IServiceCollection services)
        {
            // services.AddScoped<IApplicationService, ApplicationService>();
        }
    }
}
