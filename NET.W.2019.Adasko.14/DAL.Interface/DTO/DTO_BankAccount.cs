using System;
using BLL.Interface.Entities;

namespace DAL.Interface.DTO
{
    [Serializable]
    public class DTO_BankAccount
    {
        public int AccountNumber { get; set; }

        public string OwnerName { get; set; }

        public decimal Balance { get; set; }

        public double BonusPoints { get; set; }

        public AccountType? AccountType { get; set; }

        public BonusType? BonusType { get; set; }
    }
}
