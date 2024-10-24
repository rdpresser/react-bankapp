﻿using ReactBank.Domain.Interfaces.Repositores;

namespace ReactBank.Application.Services.Base
{
    public abstract class BaseAppService(IUnitOfWork unitOfWork)
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        protected async Task<bool> CommitAsync()
        {
            return await _unitOfWork.CommitAsync();
        }
    }
}
