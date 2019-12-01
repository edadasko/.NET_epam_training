using System;
namespace BankTask.Accounts
{
    public class BaseBankAccount : BankAccount
    {
        public BaseBankAccount(int id, string name)
        {
            this.id = id;
            this.onwerName = name;
            balance = 0;
            bonusPoints = 0;
        }

        public override double DepositBalanceCoefficient => 0.1;

        public override double DepositValueCoefficient => 0.1;

        public override double WithdrawBalanceCoefficient => 0.05;

        public override double WithdrawValueCoefficient => 0.05;
    }
}
