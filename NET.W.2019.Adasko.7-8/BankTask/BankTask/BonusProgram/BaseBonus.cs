//-----------------------------------------------------------------------
// <copyright file="BaseBonus.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BankTask.BonusProgram
{
    using System;
    using BankTask.Accounts;

    /// <summary>
    /// Base bonus decorator class.
    /// Provides standard logic of changing bonus points.
    /// </summary>
    [Serializable]
    public class BaseBonus : AccountBonusDecorator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseBonus"/> class.
        /// </summary>
        /// <param name="account">
        /// Account to decorate.
        /// </param>
        public BaseBonus(BankAccount account) : base(account)
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
