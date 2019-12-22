using System;
namespace BLL.Interface.Entities
{
    /// <summary>
    /// Gold bank account class with increased bonus coefficients.
    /// </summary>
    public class SilverBankAccount : BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SilverBankAccount"/> class.
        /// </summary>
        /// <param name="id">
        /// Id value.
        /// </param>
        /// <param name="name">
        /// Owner name value.
        /// </param>
        public SilverBankAccount(int id, string name) : base(id, name)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SilverBankAccount"/> class.
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
        public SilverBankAccount(int id, string name, decimal balance, double bonusPoints, BonusType? bonusProgram)
            : base(id, name, balance, bonusPoints, bonusProgram)
        {
        }

        public SilverBankAccount(int id, string name, BonusType? bonusProgram)
            : base(id, name, bonusProgram)
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
