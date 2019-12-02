//-----------------------------------------------------------------------
// <copyright file="BankService.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BankTask
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BankTask.Accounts;
    using BankTask.BonusProgram;
    using BankTask.Storage;

    /// <summary>
    /// Provides operations with list of bank accounts.
    /// </summary>
    public class BankService
    {
        /// <summary>
        /// Permanent storage for list of bank accounts.
        /// Should consists save and load methods.
        /// </summary>
        private readonly IBankStorage accountsStorage;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankService"/> class.
        /// </summary>
        /// <param name="storage">
        /// Permanent storage.
        /// </param>
        public BankService(IBankStorage storage)
        {
            this.accountsStorage = storage;
            this.GetAccountsFromStorage();
        }

        /// <summary>
        /// Gets list of books.
        /// </summary>
        public List<BankAccount> Accounts { get; private set; }

        /// <summary>
        /// Gets account by index.
        /// </summary>
        /// <param name="index">
        /// Index of the element in accounts list.
        /// </param>
        /// <returns>
        /// Account on the passed index.
        /// </returns>
        public BankAccount this[int index] => this.Accounts[index];

        /// <summary>
        /// Loads accounts from the storage.
        /// </summary>
        public void GetAccountsFromStorage() => this.Accounts = this.accountsStorage.GetAccounts().ToList();

        /// <summary>
        /// Saves accounts to the storage.
        /// </summary>
        public void SaveAccountsToStorage() => this.accountsStorage.SaveAccounts(this.Accounts);

        /// <summary>
        /// Adds new account to the list.
        /// </summary>
        /// <param name="account">
        /// Account to add.
        /// </param>
        public void AddAccount(BankAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException();
            }

            if (this.Accounts.Contains(account))
            {
                throw new ArgumentException("There is such account already.");
            }

            this.Accounts.Add(account);

            this.SaveAccountsToStorage();
        }

        /// <summary>
        /// Remove account from the list.
        /// </summary>
        /// <param name="account">
        /// Account to remove.
        /// </param>
        public void RemoveAccount(BankAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException();
            }

            if (!this.Accounts.Contains(account))
            {
                throw new ArgumentException("There is not such account.");
            }

            this.Accounts.Remove(account);

            this.SaveAccountsToStorage();
        }

        /// <summary>
        /// Removes all decorators from account.
        /// </summary>
        /// <param name="acc">
        /// Account to remove decorators.
        /// </param>
        public void RemoveAllBonusPrograms(BankAccount acc)
        {
            if (acc == null)
            {
                throw new ArgumentNullException();
            }

            if (!this.Accounts.Contains(acc))
            {
                throw new ArgumentException("There is not such account.");
            }

            while (acc is AccountBonusDecorator decAccount)
            {
                acc = decAccount.Account;
            }

            this.Accounts[this.Accounts.IndexOf(acc)] = acc;

            this.SaveAccountsToStorage();
        }

        /// <summary>
        /// Makes deposit to passed account.
        /// </summary>
        /// <param name="account">
        /// Account for deposit.
        /// </param>
        /// <param name="value">
        /// Value of deposit.
        /// </param>
        public void DepositToAccount(BankAccount account, decimal value) =>
            this.UpdateBalanceOfAccount(account.Deposit, account, value);

        /// <summary>
        /// Makes withdraw from passed account,
        /// </summary>
        /// <param name="account">
        /// Account for withdraw.
        /// </param>
        /// <param name="value">
        /// Value of withdraw.
        /// </param>
        public void WithdrawFromAccount(BankAccount account, decimal value) =>
            this.UpdateBalanceOfAccount(account.Withdraw, account, value);

        /// <summary>
        /// Updates account balance,
        /// </summary>
        /// <param name="action">
        /// Withdraw or Deposite method.
        /// </param>
        /// <param name="account">
        /// Account to change.
        /// </param>
        /// <param name="value">
        /// Value of changing.
        /// </param>
        private void UpdateBalanceOfAccount(Action<decimal> action, BankAccount account, decimal value)
        {
            if (account == null)
            {
                throw new ArgumentNullException();
            }

            action(value);
            this.SaveAccountsToStorage();
        }
    }
}
