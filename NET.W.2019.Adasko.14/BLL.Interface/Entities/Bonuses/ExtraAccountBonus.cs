using System;
namespace BLL.Interface.Entities
{
    /// <summary>
    /// Extra bonus decorator class.
    /// Provides additional logic of changing bonus points.
    /// </summary>
    [Serializable]
    public class ExtraAccountBonus : AccountBonusDecorator
    {
        /// <summary>
        /// Additional deposit bonus.
        /// </summary>
        private const double DepositBonus = 1.2;

        /// <summary>
        /// Additional withdraw bonus.
        /// </summary>
        private const double WithdrawBonus = 0.8;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtraAccountBonus"/> class.
        /// </summary>
        /// <param name="account">
        /// Account to decorate.
        /// </param>
        public ExtraAccountBonus(BankAccount account) : base(account)
        {
        }

        /// <inheritdoc/>
        public override double GetDepositBonus(decimal value) =>
            (DepositBonus * this.DepositBalanceCoefficient * (double)this.Account.Balance) +
                (this.DepositValueCoefficient * (double)value);

        /// <inheritdoc/>
        public override double GetWithdrawBonus(decimal value) =>
            (WithdrawBonus * this.WithdrawBalanceCoefficient * (double)this.Account.Balance) +
                (this.WithdrawValueCoefficient * (double)value);
    }
}
