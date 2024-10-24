﻿using ReactBank.Application.DataContracts;
using ReactBank.Application.Interfaces.Base;

namespace ReactBank.Application.Interfaces
{
    public interface ICustomerAppService : IBaseAppService<CustomerDataRequest, CustomerDataResponse>
    {

    }
}