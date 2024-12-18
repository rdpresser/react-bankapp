﻿using ReactBank.Application.CustomAttributes;

namespace ReactBank.Application.DataContracts
{
    public class AccountDataRequest
    {
        [RequiredValidation]
        public string AccountNumber { get; set; }
        [RequiredValidation]
        public decimal Balance { get; set; }
        public string Currency { get; set; } = "US$"; // Default value for "Currency
        [RequiredValidation]
        public string AccountType { get; set; } //Create enum for AccountType (Checking Account, Savings Account, Business Account, Joint Account, Investment Account, Student Account, Salary Account)

        [RequiredGuidValidation]
        public Guid CustomerId { get; set; }
    }
}
