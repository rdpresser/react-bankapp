﻿using ReactBank.Application.CustomAttributes;

namespace ReactBank.Application.DataContracts
{
    public class MakeDepositOperationDataRequest
    {
        [RequiredGuidValidation]
        public Guid AccountId { get; set; }
        [RequiredValidation]
        public decimal Amount { get; set; }
    }
}
