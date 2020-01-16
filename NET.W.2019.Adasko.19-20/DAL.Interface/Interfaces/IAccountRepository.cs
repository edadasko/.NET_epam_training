//-----------------------------------------------------------------------
// <copyright file="IAccountRepository.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace DAL.Interface.Interfaces
{
    using System.Collections.Generic;
    using BLL.Interface.Entities;

    /// <summary>
    /// Provides methods for bank account repository.
    /// </summary>
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
