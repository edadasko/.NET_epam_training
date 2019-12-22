//-----------------------------------------------------------------------
// <copyright file="ExtraAccountBonus.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BLL.Interface.Entities
{
    using BLL.Interface.Interfaces;

    /// <summary>
    /// Extra bonus class.
    /// Provides additional logic of changing bonus points.
    /// </summary>
    public class ExtraAccountBonus : IAccountBonus
    {
        /// <summary>
        /// Additional deposit bonus.
        /// </summary>
        private const double ExtraDepositBonus = 1.2;

        /// <summary>
        /// Additional withdraw bonus.
        /// </summary>
        private const double ExtraWithdrawBonus = 0.8;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtraAccountBonus"/> class.
        /// </summary>
        /// <param name="account">Account for bonus program.</param>
        public ExtraAccountBonus(BankAccount account)
        {
            this.Account = account;
        }

        /// <inheritdoc/>
        public BankAccount Account { get; set; }

        /// <inheritdoc/>
        public double GetDepositBonus(decimal value) =>
            (ExtraDepositBonus * this.Account.DepositBalanceCoefficient * (double)this.Account.Balance) +
                (this.Account.DepositValueCoefficient * (double)value);

        /// <inheritdoc/>
        public double GetWithdrawBonus(decimal value) =>
            (ExtraWithdrawBonus * this.Account.WithdrawBalanceCoefficient * (double)this.Account.Balance) +
                (this.Account.WithdrawValueCoefficient * (double)value);
    }
}
