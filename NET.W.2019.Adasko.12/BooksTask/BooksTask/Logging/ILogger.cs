//-----------------------------------------------------------------------
// <copyright file="ILogger.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BooksTask.Logging
{
    /// <summary>
    /// Interface for various frameworks for logging.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Writes debug information to log.
        /// </summary>
        /// <param name="message">
        /// Message arrived.
        /// </param>
        void Debug(string message);

        /// <summary>
        /// Writes information to log.
        /// </summary>
        /// <param name="message">Message arrived.</param>
        void Info(string message);

        /// <summary>
        /// Writes warning information to log.
        /// </summary>
        /// <param name="message">Message arrived.</param>
        void Warn(string message);

        /// <summary>
        /// Writes errors to log.
        /// </summary>
        /// <param name="message">Message arrived.</param>
        void Error(string message);

        /// <summary>
        /// Writes fatal errors to log.
        /// </summary>
        /// <param name="message">Message arrived.</param>
        void Fatal(string message);
    }
}
