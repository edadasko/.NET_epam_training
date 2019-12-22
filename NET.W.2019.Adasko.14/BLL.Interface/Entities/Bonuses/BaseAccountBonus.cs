using System;
namespace BLL.Interface.Entities
{
    /// <summary>
    /// Base bonus decorator class.
    /// Provides standard logic of changing bonus points.
    /// </summary>
    [Serializable]
    public class BaseAccountBonus : AccountBonusDecorator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAccountBonus"/> class.
        /// </summary>
        /// <param name="account">
        /// Account to decorate.
        /// </param>
        public BaseAccountBonus(BankAccount account) : base(account)
        {
        }

        /// <inheritdoc/>
        public override double GetDepositBonus(decimal value) =>
            (this.DepositBalanceCoefficient * (double)this.Account.Balance) +
                (this.DepositValueCoefficient * (double)value);

        /// <inheritdoc/>
        public override double GetWithdrawBonus(decimal value) =>
            (this.WithdrawBalanceCoefficient * (double)this.Account.Balance) +
                (this.WithdrawValueCoefficient * (double)value);
    }
}
