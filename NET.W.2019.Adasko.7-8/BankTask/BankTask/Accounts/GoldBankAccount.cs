using System;
namespace BankTask.Accounts
{
    public class GoldBankAccount : BankAccount
    {
        public GoldBankAccount(int id, string name) : base(id, name)
        {
            AccountType = AccountType.Gold;
        }

        public GoldBankAccount(int id, string name, decimal balance, double bonusPoints)
            : base(id, name, balance, bonusPoints)
        {
            AccountType = AccountType.Gold;
        }

        public override double DepositBalanceCoefficient => 0.5;

        public override double DepositValueCoefficient => 0.5;

        public override double WithdrawBalanceCoefficient => 0.01;

        public override double WithdrawValueCoefficient => 0.01;
    }
}
