using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using BankTask.Accounts;

namespace BankTask.Storage
{
    public class BinaryBankStorage : IBankStorage
    {
        private readonly string filePath;

        public BinaryBankStorage(string path)
        {
            this.filePath = path ?? throw new ArgumentNullException();
        }

        public IEnumerable<BankAccount> GetAccounts()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            List<BankAccount> accounts;

            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                if (fs.Length == 0)
                {
                    return new List<BankAccount>();
                }

                accounts = ((IEnumerable<BankAccount>)formatter.Deserialize(fs)).ToList();
            }

            return accounts;
        }

        public void SaveAccounts(IEnumerable<BankAccount> accounts)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, accounts);
            }
        }
    }
}
