using System;
using BLL.Interface.Interfaces;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Base bonus class.
    /// Provides standard logic of changing bonus points.
    /// </summary>
    public class BaseAccountBonus : IAccountBonus
    {
        public BankAccount Account { get; set; }

        public BaseAccountBonus(BankAccount account)
        {
            this.Account = account;
        }

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
