using System;

namespace BankTask.Accounts
{
    public enum AccountType
    {
        Base,
        Gold
    }

    public abstract class BankAccount
    {
        #region fields

        protected int id;

        protected string ownerName;

        protected decimal balance;

        protected double bonusPoints;

        #endregion

        protected BankAccount() { }

        protected BankAccount(int id, string name)
        {
            this.Id = id;
            this.OwnerName = name;
            this.Balance = 0;
            this.BonusPoints = 0;
        }

        protected BankAccount(int id, string name, decimal balance, double bonusPoints) : this(id, name)
        {
            this.Balance = balance;
            this.BonusPoints = bonusPoints;
        }

        #region properties

        public AccountType AccountType { get; set; }

        public int Id
        {
            get => id;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }

                id = value;
            }

        }

        public string OwnerName
        {
            get => ownerName;

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                ownerName = value;
            }
        }

        public virtual decimal Balance
        {
            get => this.balance;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Balance cannot be negative.");
                }

                this.balance = value;
            }
        }

        public virtual double BonusPoints
        {
            get => this.bonusPoints;

            private set
            {
                if (value < 0)
                {
                    this.bonusPoints = 0;
                }
                else
                {
                    this.bonusPoints = value;
                }
            }
        }

        public abstract double DepositBalanceCoefficient { get; }

        public abstract double DepositValueCoefficient { get; }

        public abstract double WithdrawBalanceCoefficient { get; }

        public abstract double WithdrawValueCoefficient { get; }

        #endregion

        public virtual void Deposit(int value) => Balance += value;

        public virtual void Withdraw(int value) => Balance -= value;

        public void AddBonusPoints(double value) => BonusPoints += value;

        public void RemoveBonusPoints(double value) => BonusPoints -= value;
    }
}
