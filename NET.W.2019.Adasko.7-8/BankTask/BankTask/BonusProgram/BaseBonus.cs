using System;
using BankTask.Accounts;

namespace BankTask.BonusProgram
{
    public class BaseBonus : AccountBonusDecorator
    {
        public BaseBonus(BankAccount account) : base(account) { }

        public override void Deposit(int value)
        {
            account.AddBonusPoints(
                DepositBalanceCoefficient * (double)account.Balance +
                DepositValueCoefficient * value);

            account.Deposit(value);
        }

        public override void Withdraw(int value)
        {
            account.RemoveBonusPoints(
                WithdrawBalanceCoefficient * (double)account.Balance +
                WithdrawValueCoefficient * value);

            account.Withdraw(value);
        }
    }
}
