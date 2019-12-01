using System;
using BankTask.Accounts;

namespace BankTask.BonusProgram
{
    [Serializable]
    public abstract class AccountBonusDecorator : BankAccount
    {
        protected BankAccount account;

        protected AccountBonusDecorator(BankAccount account)
        {
            this.account = account;
        }

        public abstract double GetDepositBonus(decimal value);

        public abstract double GetWithdrawBonus(decimal value);

        public override void Deposit(decimal value)
        {
            double bonusPoints = GetDepositBonus(value);

            account.Deposit(value);

            Console.WriteLine($"Your bonus points before deposit: {this.BonusPoints}");
            account.AddBonusPoints(bonusPoints);
            Console.WriteLine($"Your bonus points after deposit: {this.BonusPoints}");
        }

        public override void Withdraw(decimal value)
        {
            double bonusPoints = GetWithdrawBonus(value);

            account.Withdraw(value);

            Console.WriteLine($"Your bonus points before withdraw: {this.BonusPoints}");
            account.RemoveBonusPoints(bonusPoints);
            Console.WriteLine($"Your bonus points after withdraw: {this.BonusPoints}");
        }

        public override double DepositBalanceCoefficient => account.DepositBalanceCoefficient;

        public override double DepositValueCoefficient => account.DepositValueCoefficient;

        public override double WithdrawBalanceCoefficient => account.WithdrawBalanceCoefficient;

        public override double WithdrawValueCoefficient => account.WithdrawValueCoefficient;

        public override int Id => account.Id;

        public override string OwnerName => account.OwnerName;

        public override decimal Balance => account.Balance;

        public override double BonusPoints => account.BonusPoints;
    }
}
