using System;
using System.Collections.Generic;
using System.IO;
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
            if (!File.Exists(this.filePath))
            {
                throw new InvalidOperationException("There is not such file.");
            }

            List<BankAccount> accounts = new List<BankAccount>();

            using (BinaryReader reader = new BinaryReader(File.Open(this.filePath, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    int id = reader.ReadInt32();
                    string owner = reader.ReadString();
                    decimal balance = reader.ReadDecimal();
                    double bonus = reader.ReadDouble();
                    int type = reader.ReadInt32();

                    switch(type)
                    {
                        case (int)AccountType.Base:
                            accounts.Add(new BaseBankAccount(id, owner, balance, bonus));
                            break;
                        case (int)AccountType.Gold:
                            accounts.Add(new GoldBankAccount(id, owner, balance, bonus));
                            break;
                    }
                }
            }

            return accounts;
        }

        public void SaveAccounts(IEnumerable<BankAccount> accounts)
        {
            using BinaryWriter writer = new BinaryWriter(File.Open(this.filePath, FileMode.Create));

            foreach (var acc in accounts)
            {
                writer.Write(acc.Id);
                writer.Write(acc.OwnerName);
                writer.Write(acc.Balance);
                writer.Write(acc.BonusPoints);
                writer.Write((int)acc.AccountType);
            }
        }
    }
}
