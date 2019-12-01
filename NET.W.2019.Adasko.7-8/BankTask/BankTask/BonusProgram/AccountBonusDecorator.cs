using System;
using BankTask.Accounts;

namespace BankTask.BonusProgram
{
    public abstract class AccountBonusDecorator : BankAccount
    {
        protected BankAccount account;

        protected AccountBonusDecorator(BankAccount account)
        {
            this.account = account;
        }

        public abstract override void Deposit(int value);

        public abstract override void Withdraw(int value);

        public override double DepositBalanceCoefficient => account.DepositBalanceCoefficient;

        public override double DepositValueCoefficient => account.DepositValueCoefficient;

        public override double WithdrawBalanceCoefficient => account.WithdrawBalanceCoefficient;

        public override double WithdrawValueCoefficient => account.WithdrawValueCoefficient;

        public override decimal Balance => account.Balance;

        public override double BonusPoints => account.BonusPoints;
    }
}
