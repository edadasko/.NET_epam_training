using System;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class BankAccountMapper
    {
        public static BankAccount ConvertToBankAccount(this DTO_BankAccount dtoAccount)
        {
            return dtoAccount.AccountType switch
            {
                AccountType.Base => new BaseBankAccount(
                       dtoAccount.AccountNumber,
                       dtoAccount.OwnerName,
                       dtoAccount.Balance,
                       dtoAccount.BonusPoints,
                       dtoAccount.BonusType),

                AccountType.Gold => new GoldBankAccount(
                        dtoAccount.AccountNumber,
                        dtoAccount.OwnerName,
                        dtoAccount.Balance,
                        dtoAccount.BonusPoints,
                        dtoAccount.BonusType),

                AccountType.Silver => new SilverBankAccount(
                        dtoAccount.AccountNumber,
                        dtoAccount.OwnerName,
                        dtoAccount.Balance,
                        dtoAccount.BonusPoints,
                        dtoAccount.BonusType),

                _ => null,
            };
        }

        public static DTO_BankAccount ConvertToDTO(this BankAccount account)
        {
            return new DTO_BankAccount()
            {
                AccountNumber = account.AccountNumber,
                Balance = account.Balance,
                BonusPoints = account.BonusPoints,
                OwnerName = account.OwnerName,
                AccountType = account.GetAccountType(),
                BonusType = account.GetBonusType()
            };
        }
    }
}
