using System;
using BankTask.Accounts;

namespace BankTask.BonusProgram
{
    public class HolidayBonus : AccountBonusDecorator
    {
        private const string Congrats = "Happy Holidays!";

        private const double DepositBonus = 1.2;
        private const double WithdrawBonus = 0.8;

        public HolidayBonus(BankAccount account) : base(account) { }

        public override void Deposit(int value)
        {
            PrintCongrats();

            account.AddBonusPoints(DepositBonus *
                DepositBalanceCoefficient * (double)account.Balance +
                DepositValueCoefficient * value);

            account.Deposit(value);
        }

        public override void Withdraw(int value)
        {
            PrintCongrats();

            account.RemoveBonusPoints(WithdrawBonus *
                WithdrawBalanceCoefficient * (double)account.Balance +
                WithdrawValueCoefficient * value);

            account.Withdraw(value);
        }

        private void PrintCongrats() =>
            Console.WriteLine(Congrats);
    }
}
