//-----------------------------------------------------------------------
// <copyright file="DTO_BankAccount.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace DAL.Interface.DTO
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using BLL.Interface.Entities;

    /// <summary>
    /// DTO bank account class for working with repository.
    /// </summary>
    [Serializable]
    public class DTO_BankAccount
    {
        [Key]
        /// Gets or sets Id for storing in database.
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets unique account number.
        /// </summary>
        public int AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets owner name.
        /// </summary>
        public string OwnerName { get; set; }

        /// <summary>
        /// Gets or sets current balance.
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Gets or sets number of bonus points.
        /// </summary>
        public double BonusPoints { get; set; }

        /// <summary>
        /// Gets or sets account type.
        /// </summary>
        public AccountType? AccountType { get; set; }

        /// <summary>
        /// Gets or sets type of bonus program.
        /// </summary>
        public BonusType? BonusType { get; set; }
    }
}
