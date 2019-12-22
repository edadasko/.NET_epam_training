//-----------------------------------------------------------------------
// <copyright file="BankAccountMapper.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BLL.Mappers
{
    using BLL.Interface.Entities;
    using DAL.Interface.DTO;

    /// <summary>
    /// Helps with accounts converting.
    /// </summary>
    public static class BankAccountMapper
    {
        /// <summary>
        /// Converts BLL account to DTO account.
        /// </summary>
        /// <param name="account">Account for converting.</param>
        /// <returns>Converted account.</returns>
        public static DTO_BankAccount ConvertToDTO(this BankAccount account)
        {
            return new DTO_BankAccount
            {
                AccountNumber = account.AccountNumber,
                Balance = account.Balance,
                BonusPoints = account.BonusPoints,
                OwnerName = account.OwnerName,
                AccountType = account.GetAccountType(),
                BonusType = account.GetBonusType()
            };
        }

        /// <summary>
        /// Converts DTO account to BLL account.
        /// </summary>
        /// <param name="dtoAccount">Account for converting.</param>
        /// <returns>Converted account.</returns>
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
    }
}
