//-----------------------------------------------------------------------
// <copyright file="BinaryBankStorage.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BankTask.Storage
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;
    using BankTask.Accounts;

    /// <summary>
    /// Provides permanent storage for bank accounts list using binary file.
    /// </summary>
    public class BinaryBankStorage : IBankStorage
    {
        /// <summary>
        /// Path to the binary file.
        /// </summary>
        private readonly string filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryBankStorage"/> class.
        /// </summary>
        /// <param name="path">
        /// Path to the binary file.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws when the path is null.
        /// </exception>
        public BinaryBankStorage(string path)
        {
            this.filePath = path ?? throw new ArgumentNullException();
        }

        /// <inheritdoc />
        public IEnumerable<BankAccount> GetAccounts()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            List<BankAccount> accounts;

            using (FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate))
            {
                if (fs.Length == 0)
                {
                    return new List<BankAccount>();
                }

                accounts = ((IEnumerable<BankAccount>)formatter.Deserialize(fs)).ToList();
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
