//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace ConsoleBankTest
{
    using BankTask;
    using BankTask.Accounts;
    using BankTask.BonusProgram;
    using BankTask.Storage;

    /// <summary>
    /// Tests working of the Bank seervice class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Path to binary file for permanent storage of the list.
        /// </summary>
        private const string FilePath = "bankStorage.txt";

        /// <summary>
        /// Main method of the console application.
        /// </summary>
        /// <param name="args">
        /// Passed parameters.
        /// </param>
        public static void Main(string[] args)
        {
            BankService bankService = new BankService(new BinaryBankStorage(FilePath));

            Init(bankService);

            bankService.DepositToAccount(bankService[0], 1000);
            bankService.WithdrawFromAccount(bankService[0], 100);

            bankService.RemoveAllBonusPrograms(bankService[0]);

            bankService.DepositToAccount(bankService[0], 1000);
            bankService.WithdrawFromAccount(bankService[0], 100);

            bankService.DepositToAccount(bankService[1], 1000);
            bankService.WithdrawFromAccount(bankService[1], 100);
        }

        /// <summary>
        /// Initializes bank service.
        /// </summary>
        /// <param name="bankService">
        /// Bank service to initialize.
        /// </param>
        private static void Init(BankService bankService)
        {
            BankAccount account1 = new BaseBankAccount(1, "Eduard Adasko");
            account1 = new BaseBonus(account1);
            account1 = new HolidayBonus(account1);

            BankAccount account2 = new GoldBankAccount(2, "Polina Ushakova");
            account2 = new HolidayBonus(account2);

            bankService.AddAccount(account1);
            bankService.AddAccount(account2);
        }
    }
}
