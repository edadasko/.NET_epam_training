using System;
using BankTask.Accounts;

namespace BankTask.BonusProgram
{
    [Serializable]
    public class BaseBonus : AccountBonusDecorator
    {
        public BaseBonus(BankAccount account) : base(account)
        {
        }

        public override double GetDepositBonus(decimal value) =>
            DepositBalanceCoefficient * (double)account.Balance +
                DepositValueCoefficient * (double)value;

        public override double GetWithdrawBonus(decimal value) =>
            WithdrawBalanceCoefficient * (double)account.Balance +
                WithdrawValueCoefficient * (double)value;
    }
}
