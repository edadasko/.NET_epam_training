//-----------------------------------------------------------------------
// <copyright file="SecondListener.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace TimerTask
{
    using System;

    /// <summary>
    /// Secong listener of timeout event.
    /// </summary>
    public class SecondListener
    {
        /// <summary>
        /// Method which will be executed when event will be rised. 
        /// </summary>
        /// <param name="sender">Event owner.</param>
        /// <param name="e">Event arguments.</param>
        public void OnTimerTimeout(object sender, TimerEventArgs e)
        {
            Console.WriteLine("Second listener job after {0} seconds.", e.Seconds);
        }
    }
}
