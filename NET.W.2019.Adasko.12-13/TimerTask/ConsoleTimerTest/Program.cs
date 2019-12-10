//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace ConsoleTimerTest
{
    using TimerTask;

    /// <summary>
    /// Main class in console application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Time for timer in seconds.
        /// </summary>
        private const int Time = 3;

        /// <summary>
        /// Starts program
        /// </summary>
        public static void Main()
        {
            Timer timer = new Timer();

            FirstListener firstListener = new FirstListener();
            SecondListener secondListener = new SecondListener();

            timer.Timeout += firstListener.OnTimerTimeout;
            timer.Timeout += secondListener.OnTimerTimeout;

            timer.StartTimer(Time);

            System.Threading.Thread.Sleep(Time * 2 * 1000);

            timer.Timeout -= firstListener.OnTimerTimeout;

            timer.StartTimer(Time);

            System.Threading.Thread.Sleep(Time * 2 * 1000);
        }
    }
}
