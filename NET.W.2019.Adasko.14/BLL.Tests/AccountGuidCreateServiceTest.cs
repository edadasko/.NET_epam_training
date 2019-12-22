using System;
using System.Collections.Generic;
using System.Linq;
using BLL.ServiceImplementation;
using NUnit.Framework;

namespace BLL.Tests
{
    public static class AccountGuidCreateServiceTest
    {
        private const int TestNum = 10000;

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
