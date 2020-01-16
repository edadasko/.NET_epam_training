//-----------------------------------------------------------------------
// <copyright file="EFAccountsRepository.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace DAL.Repositories
{
    using System.Collections.Generic;
    using BLL.Interface.Entities;
    using BLL.Mappers;
    using DAL.Interface.DTO;
    using DAL.Interface.Interfaces;

    /// <summary>
    /// Entity framework repository for working with accounts.
    /// </summary>
    public class EFAccountsRepository : IAccountRepository
    {
        private readonly AccountsContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="EFAccountsRepository"/> class.
        /// </summary>
        /// /<param name="context">EF context class for accounts.</param>
        public EFAccountsRepository(AccountsContext context)
        {
            this.context = context;
        }

        /// <inheritdoc/>
        public IEnumerable<BankAccount> GetAccounts()
        {
            var dtoRecords = this.context.Accounts;
            foreach (var record in dtoRecords)
            {
                yield return record.ConvertToBankAccount();
            }
        }

        /// <inheritdoc/>
        public void SaveAccounts(IEnumerable<BankAccount> accounts)
        {
            var dtoRecords = new List<DTO_BankAccount>();

            foreach (var account in accounts)
            {
                dtoRecords.Add(account.ConvertToDTO());
            }

            this.context.Accounts.RemoveRange(this.context.Accounts);
            this.context.Accounts.AddRange(dtoRecords);
            this.context.SaveChanges();
        }
    }
}
