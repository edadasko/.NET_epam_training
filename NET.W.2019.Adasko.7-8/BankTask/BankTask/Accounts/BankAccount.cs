using System;

namespace BankTask.Accounts
{
    public abstract class BankAccount
    {
        #region fields

        protected int id;

        protected string onwerName;

        protected decimal balance;

        protected double bonusPoints;

        #endregion

        #region properties

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
