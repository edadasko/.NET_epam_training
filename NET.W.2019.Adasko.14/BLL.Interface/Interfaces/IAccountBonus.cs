//-----------------------------------------------------------------------
// <copyright file="IAccountBonus.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BLL.Interface.Interfaces
{
    using BLL.Interface.Entities;

    /// <summary>
    /// Provides methods for working with bonus program.
    /// </summary>
    public interface IAccountBonus
    {
        /// <summary>
        /// Gets or sets an account for bonus program.
        /// </summary>
        BankAccount Account { get; set; }

        /// <summary>
        /// Gets deposit bonus.
        /// </summary>
        /// <param name="value">Value of deposit.</param>
        /// <returns>Deposit bonus.</returns>
        double GetDepositBonus(decimal value);

        /// <summary>
        /// Gets withdraw bonus.
        /// </summary>
        /// <param name="value">Value of withdraw.</param>
        /// <returns>Withdraw bonus.</returns>
        double GetWithdrawBonus(decimal value);
    }
}
