//-----------------------------------------------------------------------
// <copyright file="NLogger.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BooksTask.Logging
{
    using NLog;

    /// <summary>
    /// Class for working with NLogger. 
    /// </summary>
    public class NLogger : ILogger
    {
        /// <summary>
        /// NLogger field.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <inheritdoc/>
        public void Debug(string message) => Logger.Debug(message);

        /// <inheritdoc/>
        public void Info(string message) => Logger.Info(message);

        /// <inheritdoc/>
        public void Warn(string message) => Logger.Warn(message);

        /// <inheritdoc/>
        public void Error(string message) => Logger.Error(message);

        /// <inheritdoc/>
        public void Fatal(string message) => Logger.Fatal(message);
    }
}
