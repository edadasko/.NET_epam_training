using System;
using System.Collections.Generic;
using System.Linq;
using BankTask.Accounts;
using BankTask.Storage;

namespace BankTask
{
    public class BankService
    {
        private readonly IBankStorage accountsStorage;

        public BankService(IBankStorage storage)
        {
            this.accountsStorage = storage;
            GetAccountsFromStorage();
        }

        public List<BankAccount> Accounts { get; private set; }

        public BankAccount this[int index] => Accounts[index];

        public void GetAccountsFromStorage() => this.Accounts = this.accountsStorage.GetAccounts().ToList();

        public void SaveAccountsToStorage() => this.accountsStorage.SaveAccounts(this.Accounts);

        public void AddAccount(BankAccount account)
        {
            if(account == null)
            {
                throw new ArgumentNullException();
            }

            if (this.Accounts.Contains(account))
            {
                throw new ArgumentException("There is such account already.");
            }

            this.Accounts.Add(account);

            SaveAccountsToStorage();
        }

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

            SaveAccountsToStorage();
        }

        public void DepositToAccount(BankAccount account, decimal value) =>
            UpdateBalanceOfAccount(account.Deposit, account, value);

        public void WithdrawFromAccount(BankAccount account, decimal value) =>
            UpdateBalanceOfAccount(account.Withdraw, account, value);

        private void UpdateBalanceOfAccount(Action<decimal> action, BankAccount account, decimal value)
        {
            if (account == null)
            {
                throw new ArgumentNullException();
            }

            action(value);
            SaveAccountsToStorage();
        }
    }
}
