using System;
using BLL.Interface.Interfaces;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Base bonus decorator class.
    /// Provides standard logic of changing bonus points.
    /// </summary>
    [Serializable]
    public class BaseAccountBonus : IAccountBonus
    {
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
