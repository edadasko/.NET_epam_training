using System;
using System.Collections.Generic;
using BLL.Interface.Entities;

namespace DAL.Interface.Interfaces
{
    public interface IAccountRepository
    {
        /// <summary>
        /// Gets accounts from storage.
        /// </summary>
        /// <returns>
        /// Accounts which have been saved in the storage.
        /// </returns>
        IEnumerable<BankAccount> GetAccounts();

        /// <summary>
        /// Saves accounts to storage.
        /// </summary>
        /// <param name="accounts">
        /// Accounts to save.
        /// </param>
        void SaveAccounts(IEnumerable<BankAccount> accounts);
    }
}
