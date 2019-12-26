//-----------------------------------------------------------------------
// <copyright file="BankAccountMapper.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BLL.Mappers
{
    using System;
    using BLL.Interface.Entities;
    using BLL.Interface.Interfaces;
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
                BonusType = account.BonusType
            };
        }

        /// <summary>
        /// Converts DTO account to BLL account.
        /// </summary>
        /// <param name="dtoAccount">Account for converting.</param>
        /// <returns>Converted account.</returns>
        public static BankAccount ConvertToBankAccount(this DTO_BankAccount dtoAccount)
        {
            IAccountBonus bonusProgram = dtoAccount.BonusType switch
            {
                BonusType.Base => new BaseAccountBonus(),
                BonusType.Extra => new ExtraAccountBonus(),
                _ => throw new ArgumentException(),
            };

            return dtoAccount.AccountType switch
            {
                AccountType.Base => new BaseBankAccount(
                      dtoAccount.AccountNumber,
                      dtoAccount.OwnerName,
                      dtoAccount.Balance,
                      dtoAccount.BonusPoints,
                      bonusProgram),

                AccountType.Gold => new GoldBankAccount(
                        dtoAccount.AccountNumber,
                        dtoAccount.OwnerName,
                        dtoAccount.Balance,
                        dtoAccount.BonusPoints,
                        bonusProgram),

                AccountType.Silver => new SilverBankAccount(
                        dtoAccount.AccountNumber,
                        dtoAccount.OwnerName,
                        dtoAccount.Balance,
                        dtoAccount.BonusPoints,
                        bonusProgram),

                _ => null,
            };
        }
    }
}
