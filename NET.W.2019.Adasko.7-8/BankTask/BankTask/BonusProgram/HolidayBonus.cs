using System;
using BankTask.Accounts;

namespace BankTask.BonusProgram
{
    [Serializable]
    public class HolidayBonus : AccountBonusDecorator
    {
        private const string Congrats = "Happy Holidays!";

        private const double DepositBonus = 1.2;
        private const double WithdrawBonus = 0.8;

        public HolidayBonus(BankAccount account) : base(account)
        {
        }

        public override void Deposit(decimal value)
        {
            PrintCongrats();
            base.Deposit(value);
        }

        public override void Withdraw(decimal value)
        {
            PrintCongrats();
            base.Withdraw(value);
        }

        public override double GetDepositBonus(decimal value) =>
            DepositBonus * DepositBalanceCoefficient * (double)account.Balance +
                DepositValueCoefficient * (double)value;

        public override double GetWithdrawBonus(decimal value) =>
            WithdrawBonus * WithdrawBalanceCoefficient * (double)account.Balance +
                WithdrawValueCoefficient * (double)value;

        private void PrintCongrats()
        {
            Console.WriteLine();
            Console.WriteLine(Congrats);
        }  
    }
}
