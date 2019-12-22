//-----------------------------------------------------------------------
// <copyright file="AccountServiceTest.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BLL.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using BLL.Interface.Entities;
    using BLL.ServiceImplementation;
    using DAL.Interface.Interfaces;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Tests AccountService class.
    /// </summary>
    public static class AccountServiceTest
    {
        /// <summary>
        /// Mock for IAccountRepository.
        /// </summary>
        private static Mock<IAccountRepository> mock;

        /// <summary>
        /// AccountService for testing.
        /// </summary>
        private static AccountService service;

        /// <summary>
        /// Tests Deposit method.
        /// </summary>
        [Test]
        public static void DepositTest()
        {
            SetupMock();

            service.DepositAccount(1, 100);
            Assert.AreEqual(service.Accounts[0].Balance, 100);
        }

        /// <summary>
        /// Tests Withdraw method.
        /// </summary>
        [Test]
        public static void WithdrawTest()
        {
            SetupMock();

            service.DepositAccount(1, 100);
            service.WithdrawAccount(1, 50);
            Assert.AreEqual(service.Accounts[0].Balance, 50);
        }

        /// <summary>
        /// Tests getting bonus points.
        /// </summary>
        [Test]
        public static void BonusPointsTest()
        {
            SetupMock();

            service.DepositAccount(1, 100);
            service.DepositAccount(1, 50);

            service.DepositAccount(2, 100);
            service.WithdrawAccount(2, 50);

            Assert.IsTrue(service[1].BonusPoints > service[0].BonusPoints);
        }

        /// <summary>
        /// Tests OpenAccount method.
        /// </summary>
        [Test]
        public static void OpenAccountTest()
        {
            SetupMock();

            service.OpenAccount("3", AccountType.Gold, BonusType.Base, new AccountGuidCreateService());

            Assert.IsTrue(service.Accounts.Any(acc => acc.OwnerName == "3"));
        }

        /// <summary>
        /// Tests CloseAccount method.
        /// </summary>
        [Test]
        public static void CloseAccountTest()
        {
            SetupMock();

            service.CloseAccount(1);

            Assert.IsFalse(service.Accounts.Any(acc => acc.AccountNumber == 1));
        }

        /// <summary>
        /// Setups mock.
        /// </summary>
        private static void SetupMock()
        {
            mock = new Mock<IAccountRepository>();
            mock.Setup(a => a.GetAccounts()).Returns(
                new List<BankAccount>
                {
                    new BaseBankAccount(1, "1", BonusType.Base),
                    new GoldBankAccount(2, "2", BonusType.Extra),
                });
            service = new AccountService(mock.Object);
        }
    }
}
