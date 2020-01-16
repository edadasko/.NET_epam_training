//-----------------------------------------------------------------------
// <copyright file="IAccountService.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BLL.Interface.Interfaces
{
    using System.Collections.Generic;
    using BLL.Interface.Entities;

    /// <summary>
    /// Provides methods for working with list of accounts.
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Creates new account.
        /// </summary>
        /// <param name="name">Owner name.</param>
        /// <param name="accountType">Account type.</param>
        /// <param name="bonusType">Type of bonus program.</param>
        /// <param name="createService">Id creation service.</param>
        void OpenAccount(
            string name,
            AccountType accountType,
            IAccountBonus bonusType,
            IAccountNumberCreateService createService);

        /// <summary>
        /// Closes account with passed id.
        /// </summary>
        /// <param name="creditNumber">Id to close.</param>
        void CloseAccount(int creditNumber);

        /// <summary>
        /// Loads accounts from the storage.
        /// </summary>
        /// <returns>IEnumerable of saved accounts.</returns>
        IEnumerable<BankAccount> GetAllAccounts();

        /// <summary>
        /// Makes deposit to passed account.
        /// </summary>
        /// <param name="creditNumber">
        /// Id of account for deposit.
        /// </param>
        /// <param name="value">
        /// Value of deposit.
        /// </param>
        void DepositAccount(int creditNumber, decimal value);

        /// <summary>
        /// Makes withdraw from passed account,
        /// </summary>
        /// <param name="creditNumber">
        /// Id of account for withdraw.
        /// </param>
        /// <param name="value">
        /// Value of withdraw.
        /// </param>
        void WithdrawAccount(int creditNumber, decimal value);
    }
}
