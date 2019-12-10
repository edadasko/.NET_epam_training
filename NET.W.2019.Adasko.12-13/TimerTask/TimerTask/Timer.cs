//-----------------------------------------------------------------------
// <copyright file="Timer.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace TimerTask
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides timer event.
    /// </summary>
    public class Timer
    {
        /// <summary>
        /// Number of milliseconds in a second.
        /// </summary>
        private const int MillisecondsInSecond = 1000;

        /// <summary>
        /// Task which sleeps thread on given number of seconds and raises the Timeout event.
        /// </summary>
        private Task timing;

        /// <summary>
        /// Timer event which raises after given number of seconds.
        /// </summary>
        public event EventHandler<TimerEventArgs> Timeout;

        /// <summary>
        /// Starts timer.
        /// </summary>
        /// <param name="seconds">Number of seconds for timer.</param>
        /// <returns>If timer started successful.</returns>
        public bool StartTimer(int seconds)
        {
            if (this.timing != null)
            {
                return false;
            }

            this.timing = new Task(() =>
            {
                Thread.Sleep(seconds * MillisecondsInSecond);
                this.OnTimeout(this, new TimerEventArgs(seconds));
                timing = null;
            });

            this.timing.Start();
            return true;
        }

        /// <summary>
        /// Raises Timeout event.
        /// </summary>
        /// <param name="sender">Event owner.</param>
        /// <param name="e">Event arguments.</param>
        protected virtual void OnTimeout(object sender, TimerEventArgs e) =>
            this.Timeout?.Invoke(sender, e);
    }
}