//-----------------------------------------------------------------------
// <copyright file="IAccountNumberCreateService.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BLL.Interface.Interfaces
{
    /// <summary>
    /// Provides method for creating unique account id.
    /// </summary>
    public interface IAccountNumberCreateService
    {
        /// <summary>
        /// Creates unique account id.
        /// </summary>
        /// <returns>Unique id.</returns>
        int CreateId();
    }
}
