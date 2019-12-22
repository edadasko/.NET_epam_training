//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace ConsolePL
{
    using System;
    using System.Linq;
    using BLL.Interface.Entities;
    using BLL.Interface.Interfaces;
    using DependencyResolver;
    using Ninject;

    /// <summary>
    /// Tests operations with the program in console mode.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Ninject resolver.
        /// </summary>
        private static readonly IKernel Resolver;

        /// <summary>
        /// Initializes static members of the <see cref="Program"/> class.
        /// </summary>
        static Program()
        {
            Resolver = new StandardKernel();
            Resolver.ConfigurateResolver();
        }

        /// <summary>
        /// Starts the program.
        /// </summary>
        public static void Main()
        {
            IAccountService service = Resolver.Get<IAccountService>();
            IAccountNumberCreateService creator = Resolver.Get<IAccountNumberCreateService>();

            // InitService(service, creator);
            var creditNumbers = service.GetAllAccounts().Select(acc => acc.AccountNumber).ToArray();

            foreach (var t in creditNumbers)
            {
                service.DepositAccount(t, 100);
            }

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine(item);
            }

            foreach (var t in creditNumbers)
            {
                service.WithdrawAccount(t, 10);
            }

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Initializes serice with some entities.
        /// </summary>
        /// <param name="service">Service for initializing.</param>
        /// <param name="creator">Account ID creator.</param>
        private static void InitService(IAccountService service, IAccountNumberCreateService creator)
        {
            service.OpenAccount("Account owner 1", AccountType.Base, BonusType.Base, creator);
            service.OpenAccount("Account owner 2", AccountType.Base, BonusType.Base, creator);
            service.OpenAccount("Account owner 3", AccountType.Silver, BonusType.Extra, creator);
            service.OpenAccount("Account owner 4", AccountType.Base, BonusType.Extra, creator);
        }
    }
}
