using System;
using System.Threading;

namespace TimerImitation
{
    /// <summary>
    /// Class that provides countdown timer functionality
    /// </summary>
    public class CountdownTimer
    {
        #region Public API
        /// <summary>
        /// Event that occurs when needed timer is finish
        /// </summary>
        public event EventHandler<TimerFinishedEventArgs> TimerFinished;

        /// <summary>
        /// Set the timer based on <paramref name="seconds"/> value
        /// </summary>
        /// <param name="seconds">Needed time</param>
        /// <exception cref="ArgumentException">Throws when <paramref name="seconds"/> is equal to 0</exception>
        public void SetTimer(int seconds)
        {
            if (seconds == 0)
            {
                throw new ArgumentException($"{seconds} can't be equal to 0.");
            }

            StartTimer(seconds);
            OnTimerFinished(this, new TimerFinishedEventArgs());
        }
        #endregion

        #region Private methods
        private void StartTimer(int seconds)
        {
            Console.WriteLine($"Timer start at {DateTime.Now:T}:");
            for(int i = seconds; i >= 0; i--)
            {
                Thread.Sleep(950);
                Console.WriteLine(i);
            }
        }

        protected virtual void OnTimerFinished(object sender, TimerFinishedEventArgs e)
        {
            TimerFinished?.Invoke(sender, e);
        }
        #endregion
    }
}