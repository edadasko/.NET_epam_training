//-----------------------------------------------------------------------
// <copyright file="TimerEventArgs.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace TimerTask
{
    using System;

    /// <summary>
    /// Arguments for timer event.
    /// </summary>
    public class TimerEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimerEventArgs"/> class.
        /// </summary>
        /// <param name="seconds">Number of seconds.</param>
        public TimerEventArgs(int seconds)
        {
            this.Seconds = seconds;
        }

        /// <summary>
        /// Gets or sets number of seconds.
        /// </summary>
        public int Seconds { get; set; }
    }
}
