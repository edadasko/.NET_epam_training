//-----------------------------------------------------------------------
// <copyright file="BankAccount.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BLL.Interface.Entities
{
    using System;
    using BLL.Interface.Interfaces;

    /// <summary>
    /// Abstract Bank Account class.
    /// </summary>
    public abstract class BankAccount : IEquatable<BankAccount>, IComparable<BankAccount>
    {
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

        /// <summary>
        /// Bonus program of an account.
        /// </summary>
        private IAccountBonus bonusProgram;

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
            this.AccountNumber = id;
            this.OwnerName = name;
            this.Balance = 0;
            this.BonusPoints = 0;
            this.bonusProgram = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class.
        /// </summary>
        /// <param name="id">Id value.</param>
        /// <param name="name">Owner name value.</param>
        /// <param name="bonusProgram">Type of bonus program.</param>
        protected BankAccount(int id, string name, BonusType? bonusProgram) : this(id, name)
        {
            if (bonusProgram != null)
            {
                this.bonusProgram = bonusProgram switch
                {
                    BonusType.Base => new BaseAccountBonus(this),
                    BonusType.Extra => new ExtraAccountBonus(this),
                    _ => null,
                };
            }
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
        /// <param name="bonusProgram">Type of bonus program.</param>
        protected BankAccount(int id, string name, decimal balance, double bonusPoints, BonusType? bonusProgram)
            : this(id, name, bonusProgram)
        {
            this.Balance = balance;
            this.BonusPoints = bonusPoints;
        }

        /// <summary>
        /// Gets and sets Id.
        /// </summary>
        public int AccountNumber
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
        public string OwnerName
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
        public decimal Balance
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
        public double BonusPoints
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

        /// <summary>
        /// Increases balance of the account.
        /// </summary>
        /// <param name="value">
        /// Value for increasing.
        /// </param>
        public virtual void Deposit(decimal value)
        {
            if (this.bonusProgram != null)
            {
                double points = this.bonusProgram.GetDepositBonus(value);
                this.BonusPoints += points;
            }

            this.Balance += value;
        }

        /// <summary>
        /// Decreases balance of the account.
        /// </summary>
        /// <param name="value">
        /// Value for decreasing.
        /// </param>
        public virtual void Withdraw(decimal value)
        {
            if (this.bonusProgram != null)
            {
                double points = this.bonusProgram.GetWithdrawBonus(value);
                this.BonusPoints -= points;
            }

            this.Balance -= value;
        }

        /// <summary>
        /// Gets type of account.
        /// </summary>
        /// <returns>Type of account.</returns>
        public AccountType? GetAccountType()
        {
            if (this is BaseBankAccount)
            {
                return AccountType.Base;
            }

            if (this is SilverBankAccount)
            {
                return AccountType.Silver;
            }

            if (this is GoldBankAccount)
            {
                return AccountType.Gold;
            }

            return null;
        }

        /// <summary>
        /// Gets type of bonus program.
        /// </summary>
        /// <returns>Type of bonus program.</returns>
        public BonusType? GetBonusType()
        {
            if (this.bonusProgram is BaseAccountBonus)
            {
                return BonusType.Base;
            }

            if (this.bonusProgram is ExtraAccountBonus)
            {
                return BonusType.Extra;
            }

            return null;
        }

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
        public override int GetHashCode() => this.AccountNumber.GetHashCode();

        /// <inheritdoc/> 
        public override string ToString() =>
            string.Join(" ", this.AccountNumber.ToString(), this.OwnerName, this.Balance, this.BonusPoints);

        /// <inheritdoc/> 
        public bool Equals(BankAccount other)
        {
            if (other == null)
            {
                return false;
            }

            return this.AccountNumber == other.AccountNumber;
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
    }
}
