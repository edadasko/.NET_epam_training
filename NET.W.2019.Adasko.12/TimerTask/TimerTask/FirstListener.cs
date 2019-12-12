//-----------------------------------------------------------------------
// <copyright file="FirstListener.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace TimerTask
{
    using System;

    /// <summary>
    /// First listener of timeout event.
    /// </summary>
    public class FirstListener
    {
        /// <summary>
        /// Method which will be executed when event will be rised. 
        /// </summary>
        /// <param name="sender">Event owner.</param>
        /// <param name="e">Event arguments.</param>
        public void OnTimerTimeout(object sender, TimerEventArgs e)
        {
            Console.WriteLine("First listener job after {0} seconds.", e.Seconds);
        }
    }
}
