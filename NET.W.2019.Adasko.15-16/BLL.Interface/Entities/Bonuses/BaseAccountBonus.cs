//-----------------------------------------------------------------------
// <copyright file="BaseAccountBonus.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BLL.Interface.Entities
{
    using BLL.Interface.Interfaces;

    /// <summary>
    /// Base bonus class.
    /// Provides standard logic of changing bonus points.
    /// </summary>
    public class BaseAccountBonus : IAccountBonus
    {
        /// <inheritdoc/>
        public BonusType BonusType => BonusType.Base;

        /// <inheritdoc/>
        public BankAccount Account { get; set; }

        /// <inheritdoc/>
        public double GetDepositBonus(decimal value) =>
            (this.Account.DepositBalanceCoefficient * (double)this.Account.Balance) +
                (this.Account.DepositValueCoefficient * (double)value);

        /// <inheritdoc/>
        public double GetWithdrawBonus(decimal value) =>
            (this.Account.WithdrawBalanceCoefficient * (double)this.Account.Balance) +
                (this.Account.WithdrawValueCoefficient * (double)value);
    }
}
