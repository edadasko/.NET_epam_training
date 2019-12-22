using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using BLL.Interface.Entities;
using BLL;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.Repositories
{
    public class BinaryAccountRepository : IAccountRepository
    {
        /// <summary>
        /// Path to the binary file.
        /// </summary>
        private readonly string filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryAccountRepository"/> class.
        /// </summary>
        /// <param name="path">
        /// Path to the binary file.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws when the path is null.
        /// </exception>
        public BinaryAccountRepository(string path)
        {
            this.filePath = path ?? throw new ArgumentNullException();
        }

        /// <inheritdoc />
        public IEnumerable<BankAccount> GetAccounts()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            List<DTO_BankAccount> dtoAccounts;

            using (FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate))
            {
                if (fs.Length == 0)
                {
                    return new List<BankAccount>();
                }

                dtoAccounts = ((IEnumerable<DTO_BankAccount>)formatter.Deserialize(fs)).ToList();
            }

            List<BankAccount> accounts = new List<BankAccount>();
            foreach(var acc in dtoAccounts)
            {
                accounts.Add(BankAccountMapper)
            }
            return accounts;
        }

        /// <inheritdoc />
        public void SaveAccounts(IEnumerable<BankAccount> accounts)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, accounts);
            }
        }
    }
}
