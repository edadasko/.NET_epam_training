using System;
using BankTask.Accounts;

namespace BankTask.BonusProgram
{
    public class HolidayBonus : AccountBonusDecorator
    {
        private const string Congrats = "Happy Holydays!";


        public HolidayBonus(BankAccount account) : base(account) { }

        public override void Deposit(int value)
        {
            PrintCongrats();

            account.AddBonusPoints(1.2 *
                DepositBalanceCoefficient * (double)account.Balance +
                DepositValueCoefficient * value);

            account.Deposit(value);
        }

        public override void Withdraw(int value)
        {
            PrintCongrats();

            account.RemoveBonusPoints(0.8 *
                WithdrawBalanceCoefficient * (double)account.Balance +
                WithdrawValueCoefficient * value);

            account.Withdraw(value);
        }

        private void PrintCongrats() =>
            Console.WriteLine(Congrats);
    }
}
