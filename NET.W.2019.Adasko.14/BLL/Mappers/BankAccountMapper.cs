using System;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class BankAccountMapper
    {
        public static BankAccount ConvertToBankAccount(this DTO_BankAccount dtoAccount)
        {
            switch(dtoAccount.AccountType)
            {
                case AccountType.Base:
                    return new BaseBankAccount(
                       dtoAccount.AccountNumber,
                       dtoAccount.OwnerName,
                       dtoAccount.Balance,
                       dtoAccount.BonusPoints,
                       dtoAccount.BonusType);

                case AccountType.Gold:
                    return new GoldBankAccount(
                        dtoAccount.AccountNumber,
                        dtoAccount.OwnerName,
                        dtoAccount.Balance,
                        dtoAccount.BonusPoints,
                        dtoAccount.BonusType);

                case AccountType.Silver:
                    return new SilverBankAccount(
                        dtoAccount.AccountNumber,
                        dtoAccount.OwnerName,
                        dtoAccount.Balance,
                        dtoAccount.BonusPoints,
                        dtoAccount.BonusType);
                default:
                    return null;
            }

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
