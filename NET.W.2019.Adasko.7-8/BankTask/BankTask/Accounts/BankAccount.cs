using System;
using System.Diagnostics.CodeAnalysis;

namespace BankTask.Accounts
{
    [Serializable]
    public abstract class BankAccount : IEquatable<BankAccount>, IComparable<BankAccount>
    {
        #region fields

        private int id;

        private string ownerName;

        private decimal balance;

        private double bonusPoints;

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

        public virtual int Id
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

        public virtual string OwnerName
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

        public virtual void Deposit(decimal value)
        {
            Console.WriteLine();
            Console.WriteLine($"Your balance before deposit: {this.Balance}");
            Balance += value;
            Console.WriteLine($"Your balance after deposit: {this.Balance}");
        } 

        public virtual void Withdraw(decimal value)
        {
            Console.WriteLine();
            Console.WriteLine($"Your balance before withdraw: {this.Balance}");
            Balance -= value;
            Console.WriteLine($"Your balance after withdraw: {this.Balance}");
        }

        public void AddBonusPoints(double value) => BonusPoints += value;

        public void RemoveBonusPoints(double value) => BonusPoints -= value;

        #region Object's methods

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is BankAccount account)
            {
                return this.Equals(account);
            }
            return false;
        }

        public override int GetHashCode() => this.Id.GetHashCode();

        public override string ToString() => string.Join(' ', Id.ToString(), OwnerName);

        #endregion

        public bool Equals(BankAccount other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Id == other.Id;
        }

        public int CompareTo(BankAccount other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            return this.id.CompareTo(other.id);
        }
    }
}
