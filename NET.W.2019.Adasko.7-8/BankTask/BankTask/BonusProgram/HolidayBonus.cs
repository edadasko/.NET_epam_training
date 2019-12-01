//-----------------------------------------------------------------------
// <copyright file="HolidayBonus.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BankTask.BonusProgram
{
    using System;
    using BankTask.Accounts;

    /// <summary>
    /// Holiday bonus decorator class.
    /// Provides additional logic of changing bonus points.
    /// </summary>
    [Serializable]
    public class HolidayBonus : AccountBonusDecorator
    {
        /// <summary>
        /// Message of congratulations.
        /// </summary>
        private const string Congrats = "Happy Holidays!";

        /// <summary>
        /// Additional deposit bonus in honor of the holiday.
        /// </summary>
        private const double DepositBonus = 1.2;

        /// <summary>
        /// Additional withdraw bonus in honor of the holiday.
        /// </summary>
        private const double WithdrawBonus = 0.8;

        /// <summary>
        /// Initializes a new instance of the <see cref="HolidayBonus"/> class.
        /// </summary>
        /// <param name="account">
        /// Account to decorate.
        /// </param>
        public HolidayBonus(BankAccount account) : base(account)
        {
        }

        /// <inheritdoc/>
        public override void Deposit(decimal value)
        {
            this.PrintCongrats();
            base.Deposit(value);
        }

        /// <inheritdoc/>
        public override void Withdraw(decimal value)
        {
            this.PrintCongrats();
            base.Withdraw(value);
        }

        /// <inheritdoc/>
        public override double GetDepositBonus(decimal value) =>
            (DepositBonus * this.DepositBalanceCoefficient * (double)this.Account.Balance) +
                (this.DepositValueCoefficient * (double)value);

        /// <inheritdoc/>
        public override double GetWithdrawBonus(decimal value) =>
            (WithdrawBonus * this.WithdrawBalanceCoefficient * (double)this.Account.Balance) +
                (this.WithdrawValueCoefficient * (double)value);

        /// <summary>
        /// Prints holiday congratulations.
        /// </summary>
        private void PrintCongrats()
        {
            Console.WriteLine();
            Console.WriteLine(Congrats);
        }  
    }
}
