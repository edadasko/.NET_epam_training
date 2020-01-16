//-----------------------------------------------------------------------
// <copyright file="AccountGuidCreateService.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BLL.ServiceImplementation
{
    using System;
    using BLL.Interface.Interfaces;

    /// <summary>
    /// Creates GUID for account id.
    /// </summary>
    public class AccountGuidCreateService : IAccountNumberCreateService
    {
        /// <inheritdoc/>
        public int CreateId() => Math.Abs(Guid.NewGuid().GetHashCode());
    }
}
