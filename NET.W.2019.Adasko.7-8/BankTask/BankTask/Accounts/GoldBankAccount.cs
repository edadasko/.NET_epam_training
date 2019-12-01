using System;
namespace BankTask.Accounts
{
    public class GoldBankAccount : BankAccount
    {
        public GoldBankAccount(int id, string name)
        {
            this.id = id;
            this.onwerName = name;
            balance = 0;
            bonusPoints = 0;
        }

        public override double DepositBalanceCoefficient => 0.5;

        public override double DepositValueCoefficient => 0.5;

        public override double WithdrawBalanceCoefficient => 0.01;

        public override double WithdrawValueCoefficient => 0.01;
    }
}
