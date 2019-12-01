//-----------------------------------------------------------------------
// <copyright file="IBankStorage.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BankTask.Storage
{
    using System.Collections.Generic;
    using BankTask.Accounts;

    /// <summary>
    /// Interface for permanent storage of list of bank accounts.
    /// </summary>
    public interface IBankStorage
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
