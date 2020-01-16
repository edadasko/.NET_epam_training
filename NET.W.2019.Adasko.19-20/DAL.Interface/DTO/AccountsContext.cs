//-----------------------------------------------------------------------
// <copyright file="AccountsContext.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace DAL.Interface.DTO
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Context class for working with accounts using EntityFramework.
    /// </summary>
    public class AccountsContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountsContext"/> class.
        /// </summary>
        public AccountsContext(DbContextOptions<AccountsContext> options)
             : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Gets or sets accounts.
        /// </summary>
        public DbSet<DTO_BankAccount> Accounts { get; set; }
    }
}
