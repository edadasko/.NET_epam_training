//-----------------------------------------------------------------------
// <copyright file="AccountService.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BLL.ServiceImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BLL.Interface.Entities;
    using BLL.Interface.Interfaces;
    using DAL.Interface.Interfaces;

    /// <summary>
    /// Provides operations with list of bank accounts.
    /// </summary>
    public class AccountService : IAccountService
    {
        /// <summary>
        /// Permanent storage for list of bank accounts.
        /// Should consists save and load methods.
        /// </summary>
        private readonly IAccountRepository accountsStorage;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountService"/> class.
        /// </summary>
        /// <param name="storage">
        /// Permanent storage.
        /// </param>
        public AccountService(IAccountRepository storage)
        {
            this.accountsStorage = storage;
            this.GetAllAccounts();
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

        /// <inheritdoc/>
        public IEnumerable<BankAccount> GetAllAccounts()
        {
            this.Accounts = this.accountsStorage.GetAccounts().ToList();
            return this.Accounts;
        }

        /// <inheritdoc/>
        public void OpenAccount(string name, AccountType accountType, BonusType? bonusType, IAccountNumberCreateService createService)
        {
            BankAccount newAccount = null;

            int id = createService.CreateId();

            while (this.Accounts.Any(a => a.AccountNumber == id))
            {
                id = createService.CreateId();
            }

            switch (accountType)
            {
                case AccountType.Base:
                    newAccount = new BaseBankAccount(id, name, bonusType);
                    break;
                case AccountType.Silver:
                    newAccount = new SilverBankAccount(id, name, bonusType);
                    break;
                case AccountType.Gold:
                    newAccount = new GoldBankAccount(id, name, bonusType);
                    break;
            }

            this.Accounts.Add(newAccount);

            this.SaveAccountsToStorage();
        }

        /// <inheritdoc/>
        public void CloseAccount(int creditNumber)
        {
            BankAccount acc = this.Accounts.Find(a => a.AccountNumber == creditNumber);
            if (acc != null)
            {
                this.Accounts.Remove(acc);
                this.SaveAccountsToStorage();
            }
            else
            {
                throw new ArgumentException("There is not such account.");
            }
        }

        /// <inheritdoc/>
        public void DepositAccount(int id, decimal value)
        {
            BankAccount account = this.Accounts.Single(acc => acc.AccountNumber == id);
            this.UpdateBalanceOfAccount(account.Deposit, account, value);
        }

        /// <inheritdoc/>
        public void WithdrawAccount(int id, decimal value)
        {
            BankAccount account = this.Accounts.Single(acc => acc.AccountNumber == id);
            this.UpdateBalanceOfAccount(account.Withdraw, account, value);
        }

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

        /// <summary>
        /// Saves accounts to the storage.
        /// </summary>
        private void SaveAccountsToStorage() => this.accountsStorage.SaveAccounts(this.Accounts);
    }
}
