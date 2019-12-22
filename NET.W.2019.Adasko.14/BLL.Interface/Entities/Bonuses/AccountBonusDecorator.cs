using System;
namespace BLL.Interface.Entities
{
    /// <summary>
    /// Abstract decorator for bank accounts classes.
    /// Uses to add logic of changing bonus points to the account methods.
    /// </summary>
    [Serializable]
    public abstract class AccountBonusDecorator : BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountBonusDecorator"/> class.
        /// </summary>
        /// <param name="account">
        /// Account to decorate.
        /// </param>
        protected AccountBonusDecorator(BankAccount account)
        {
            this.Account = account;
        }

        /// <summary>
        /// Gets or sets account to decorate.
        /// </summary>
        public BankAccount Account { get; protected set; }

        /// <inheritdoc/>
        public override int AccountNumber => this.Account.AccountNumber;

        /// <inheritdoc/>
        public override string OwnerName => this.Account.OwnerName;

        /// <inheritdoc/>
        public override decimal Balance => this.Account.Balance;

        /// <inheritdoc/>
        public override double BonusPoints => this.Account.BonusPoints;

        /// <inheritdoc/>
        public override double DepositBalanceCoefficient => this.Account.DepositBalanceCoefficient;

        /// <inheritdoc/>
        public override double DepositValueCoefficient => this.Account.DepositValueCoefficient;

        /// <inheritdoc/>
        public override double WithdrawBalanceCoefficient => this.Account.WithdrawBalanceCoefficient;

        /// <inheritdoc/>
        public override double WithdrawValueCoefficient => this.Account.WithdrawValueCoefficient;

        /// <summary>
        /// Determines how deposit bonuses will be calculated.
        /// </summary>
        /// <param name="value">
        /// Value of deposite.
        /// </param>
        /// <returns>
        /// Value of deposit bonus.
        /// </returns>
        public abstract double GetDepositBonus(decimal value);

        /// <summary>
        /// Determines how withdraw bonuses will be calculated.
        /// </summary>
        /// <param name="value">
        /// Value of withdraw.
        /// </param>
        /// <returns>
        /// Value of withdraw bonus.
        /// </returns>
        public abstract double GetWithdrawBonus(decimal value);

        /// <summary>
        /// Adds base logic of changing bonuses to deposit method of the account.
        /// </summary>
        /// <param name="value">
        /// Value of deposit.
        /// </param>
        public override void Deposit(decimal value)
        {
            double bonusPoints = this.GetDepositBonus(value);

            this.Account.Deposit(value);

            this.Account.AddBonusPoints(bonusPoints);
        }

        /// <summary>
        /// Adds base logic of changing bonuses to withdraw method of the account.
        /// </summary>
        /// <param name="value">
        /// Value of withdraw.
        /// </param>
        public override void Withdraw(decimal value)
        {
            double bonusPoints = this.GetWithdrawBonus(value);

            this.Account.Withdraw(value);

            this.Account.RemoveBonusPoints(bonusPoints);
        }

        /// <inheritdoc/>
        public override void AddBonusPoints(double value) => this.Account.AddBonusPoints(value);

        /// <inheritdoc/>
        public override void RemoveBonusPoints(double value) => this.Account.RemoveBonusPoints(value);
    }
}
