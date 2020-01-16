//-----------------------------------------------------------------------
// <copyright file="AccountGuidCreateServiceTest.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BLL.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using BLL.ServiceImplementation;
    using NUnit.Framework;

    /// <summary>
    /// Tests AccountGuidCreateService class.
    /// </summary>
    public static class AccountGuidCreateServiceTest
    {
        /// <summary>
        /// Nums of identificators for creation.
        /// </summary>
        private const int TestNum = 10000;

        /// <summary>
        /// Test Create method of AccountGuidCreateService class.
        /// </summary>
        [Test]
        public static void CreationUniqueIdTest()
        {
            AccountGuidCreateService accountGuidCreateService = new AccountGuidCreateService();
            List<int> nums = new List<int>();

            for (int i = 0; i < TestNum; i++)
            {
                nums.Add(accountGuidCreateService.CreateId());
            }

            Assert.AreEqual(nums.Count, nums.Distinct().ToList().Count);
        }
    }
}
