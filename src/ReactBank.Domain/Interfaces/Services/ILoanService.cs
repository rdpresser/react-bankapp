﻿using ReactBank.Domain.Interfaces.Services.Base;
using ReactBank.Domain.Models;

namespace ReactBank.Domain.Interfaces.Services
{
    public interface ILoanService : IBaseService<Loan>
    {
        Task<IEnumerable<Loan>> GetAllAsync();
    }
}
