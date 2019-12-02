//-----------------------------------------------------------------------
// <copyright file="BankAccount.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BankTask.Accounts
{
    using System;

    /// <summary>
    /// Abstract Bank Account class.
    /// </summary>
    [Serializable]
    public abstract class BankAccount : IEquatable<BankAccount>, IComparable<BankAccount>
    {
        #region fields

        /// <summary>
        /// Id field.
        /// </summary>
        private int id;

        /// <summary>
        /// Owner name field.
        /// </summary>
        private string ownerName;

        /// <summary>
        /// Balance field.
        /// </summary>
        private decimal balance;

        /// <summary>
        /// Bonus points field.
        /// </summary>
        private double bonusPoints;

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class.
        /// </summary>
        protected BankAccount()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class.
        /// </summary>
        /// <param name="id">
        /// Id value.
        /// </param>
        /// <param name="name">
        /// Owner name value.
        /// </param>
        protected BankAccount(int id, string name)
        {
            this.Id = id;
            this.OwnerName = name;
            this.Balance = 0;
            this.BonusPoints = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class.
        /// </summary>
        /// <param name="id">
        /// Id value.
        /// </param>
        /// <param name="name">
        /// Owner name value.
        /// </param>
        /// <param name="balance">
        /// Balance value.
        /// </param>
        /// <param name="bonusPoints">
        /// Bonus points value.
        /// </param>
        protected BankAccount(int id, string name, decimal balance, double bonusPoints) : this(id, name)
        {
            this.Balance = balance;
            this.BonusPoints = bonusPoints;
        }
        #endregion

        #region properties

        /// <summary>
        /// Gets and sets Id.
        /// </summary>
        public virtual int Id
        {
            get => this.id;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }

                this.id = value;
            }
        }

        /// <summary>
        /// Gets and sets Owner name.
        /// </summary>
        public virtual string OwnerName
        {
            get => this.ownerName;

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                this.ownerName = value;
            }
        }

        /// <summary>
        /// Gets and sets Balance.
        /// </summary>
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

        /// <summary>
        /// Gets and sets Bonus points.
        /// </summary>
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

        /// <summary>
        /// Gets Deposit Balance Coefficient.
        /// It is used in calculating bonus points.
        /// </summary>
        public abstract double DepositBalanceCoefficient { get; }

        /// <summary>
        /// Gets Deposit Value Coefficient.
        /// It is used in calculating bonus points.
        /// </summary>
        public abstract double DepositValueCoefficient { get; }

        /// <summary>
        /// Gets Withdraw Balance Coefficient.
        /// It is used in calculating bonus points.
        /// </summary>
        public abstract double WithdrawBalanceCoefficient { get; }

        /// <summary>
        /// Gets Withdraw Value Coefficient.
        /// It is used in calculating bonus points.
        /// </summary>
        public abstract double WithdrawValueCoefficient { get; }

        #endregion

        #region methods

        /// <summary>
        /// Increases balance of the account.
        /// </summary>
        /// <param name="value">
        /// Value for increasing.
        /// </param>
        public virtual void Deposit(decimal value)
        {
            Console.WriteLine();
            Console.WriteLine($"Your balance before deposit: {this.Balance}");
            this.Balance += value;
            Console.WriteLine($"Your balance after deposit: {this.Balance}");
        }

        /// <summary>
        /// Decreases balance of the account.
        /// </summary>
        /// <param name="value">
        /// Value for decreasing.
        /// </param>
        public virtual void Withdraw(decimal value)
        {
            Console.WriteLine();
            Console.WriteLine($"Your balance before withdraw: {this.Balance}");
            this.Balance -= value;
            Console.WriteLine($"Your balance after withdraw: {this.Balance}");
        }

        /// <summary>
        /// Increases bonus points of the account.
        /// </summary>
        /// <param name="value">
        /// Value for increasing.
        /// </param>
        public virtual void AddBonusPoints(double value) => this.BonusPoints += value;

        /// <summary>
        /// Decreases bonus points of the account.
        /// </summary>
        /// <param name="value">
        /// Value for decreasing.
        /// </param>
        public virtual void RemoveBonusPoints(double value) => this.BonusPoints -= value;

        #endregion

        #region Object's methods

        /// <inheritdoc/> 
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

        /// <inheritdoc/> 
        public override int GetHashCode() => this.Id.GetHashCode();

        /// <inheritdoc/> 
        public override string ToString() => string.Join(' ', this.Id.ToString(), this.OwnerName);

        #endregion

        #region methods of interfaces

        /// <inheritdoc/> 
        public bool Equals(BankAccount other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Id == other.Id;
        }

        /// <inheritdoc/> 
        public int CompareTo(BankAccount other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            return this.id.CompareTo(other.id);
        }
        #endregion
    }
}
