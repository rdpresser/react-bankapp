using ReactBank.Domain.Interfaces.Repositores;
using ReactBank.Domain.Interfaces.Services;
using ReactBank.Domain.Models;
using ReactBank.Domain.Services.Base;

namespace ReactBank.Domain.Services
{
    public class AccountService(IAccountRepository accountRepository) : BaseService<Account>(accountRepository), IAccountService
    {
    }
}
