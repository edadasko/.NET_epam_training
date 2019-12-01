using System;
using BankTask;
using BankTask.Accounts;
using BankTask.BonusProgram;
using BankTask.Storage;
namespace ConsoleBankTest
{
    class Program
    {
        const string filePath = "bankStorage.txt";

        static void Main(string[] args)
		{
            BankService bankService = new BankService(new BinaryBankStorage(filePath));
            Init(bankService);

            bankService.DepositToAccount(bankService[0], 1000);
            bankService.WithdrawFromAccount(bankService[0], 100);
            bankService.DepositToAccount(bankService[1], 1000);
            bankService.WithdrawFromAccount(bankService[1], 100);

        }

        public static void Init(BankService bankService)
        {
            BankAccount account1 = new BaseBankAccount(1, "Eduard Adasko");
            account1 = new BaseBonus(account1);

            BankAccount account2 = new GoldBankAccount(2, "Polina Ushakova");
            account2 = new HolidayBonus(account2);

            bankService.AddAccount(account1);
            bankService.AddAccount(account2);
        }
    }
}
