using System;
using BankTask.Accounts;
using BankTask.BonusProgram;

namespace ConsoleBankTest
{
    class Program
    {
        static void Main(string[] args)
		{
            BankAccount account1 = new BaseBankAccount(1, "Eduard Adasko");
            account1 = new BaseBonus(account1);

            account1.Deposit(1000);
            Console.WriteLine(account1.BonusPoints);

            account1.Withdraw(200);
            Console.WriteLine(account1.BonusPoints);
            
            BankAccount account2 = new GoldBankAccount(2, "Polina Ushakova");
            account2 = new HolidayBonus(account2);

            account2.Deposit(1000);
            Console.WriteLine(account2.BonusPoints);

            account2.Withdraw(200);
            Console.WriteLine(account2.BonusPoints);
        }
    }
}
