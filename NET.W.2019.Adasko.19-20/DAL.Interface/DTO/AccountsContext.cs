using Microsoft.EntityFrameworkCore;

namespace DAL.Interface.DTO
{
    /// <summary>
    /// Context class for working with accounts using EntityFramework.
    /// </summary>
    public class AccountsContext : DbContext
    {
        /// <summary>
        /// Gets or sets accounts.
        /// </summary>
        public DbSet<DTO_BankAccount> Accounts { get; set; }

        /// <summary>
        /// Inializes a new instance of the <see cref="AccountsContext"/> class.
        /// </summary>
        public AccountsContext()
        {
            Database.EnsureCreated();
        }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433; Database=AccountsDBTest; User=SA; Password=Edik3003");
        }
    }
}
