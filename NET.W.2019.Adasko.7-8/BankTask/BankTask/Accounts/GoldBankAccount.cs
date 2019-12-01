//-----------------------------------------------------------------------
// <copyright file="GoldBankAccount.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BankTask.Accounts
{
    using System;

    /// <summary>
    /// Gold bank account class with increased bonus coefficients.
    /// </summary>
    [Serializable]
    public class GoldBankAccount : BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GoldBankAccount"/> class.
        /// </summary>
        /// <param name="id">
        /// Id value.
        /// </param>
        /// <param name="name">
        /// Owner name value.
        /// </param>
        public GoldBankAccount(int id, string name) : base(id, name)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoldBankAccount"/> class.
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
        public GoldBankAccount(int id, string name, decimal balance, double bonusPoints)
            : base(id, name, balance, bonusPoints)
        {
        }

        /// <inheritdoc/> 
        public override double DepositBalanceCoefficient => 0.5;

        /// <inheritdoc/> 
        public override double DepositValueCoefficient => 0.5;

        /// <inheritdoc/> 
        public override double WithdrawBalanceCoefficient => 0.01;

        /// <inheritdoc/> 
        public override double WithdrawValueCoefficient => 0.01;
    }
}
