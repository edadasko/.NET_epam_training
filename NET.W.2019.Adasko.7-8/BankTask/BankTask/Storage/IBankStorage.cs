using System;
using System.Collections.Generic;
using BankTask.Accounts;

namespace BankTask.Storage
{
    public interface IBankStorage
    {
        IEnumerable<BankAccount> GetAccounts();

        void SaveAccounts(IEnumerable<BankAccount> accounts);
    }
}
