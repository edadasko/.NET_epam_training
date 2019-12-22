using System;
using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IAccountService
    {
        void OpenAccount(
            string name,
            AccountType accountType,
            BonusType? bonusType,
            IAccountNumberCreateService createService);

        void CloseAccount(int creditNumber);

        IEnumerable<BankAccount> GetAllAccounts();

        void DepositAccount(int creditNumber, decimal value);

        void WithdrawAccount(int creditNumber, decimal value);
    }
}
