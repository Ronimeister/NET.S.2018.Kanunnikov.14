using System;
using System.Collections.Generic;
using TimerImitation;

namespace TimerConsoleTests
{
    /// <summary>
    /// Class provides abstract class for <see cref="CountdownTimer"/> observer
    /// </summary>
    public abstract class AbstractTimeObserver
    {
        #region Fields
        private List<string> _triggerResults = new List<string>();
        #endregion

        #region Public API
        /// <summary>
        /// Get all triggers of needed <see cref="CountdownTimer"/> observer
        /// </summary>
        /// <returns>all triggers of needed <see cref="CountdownTimer"/> observer</returns>
        public List<string> Triggers() => _triggerResults;

        /// <summary>
        /// Register needed <see cref="CountdownTimer"/> observer to <paramref name="timer"/>
        /// </summary>
        /// <param name="timer"><see cref="CountdownTimer"/> timer</param>
        /// <exception cref="ArgumentNullException">Throw when <paramref name="timer"/> is equal to null</exception>
        public void Register(CountdownTimer timer)
        {
            if (timer == null)
            {
                throw new ArgumentNullException($"{nameof(timer)} can't be equal to null!");
            }

            timer.TimerFinished += InvokeAction;
        }

        /// <summary>
        /// Unregister needed <see cref="CountdownTimer"/> observer to <paramref name="timer"/>
        /// </summary>
        /// <param name="timer"><see cref="CountdownTimer"/> timer</param>
        /// <exception cref="ArgumentNullException">Throw when <paramref name="timer"/> is equal to null</exception>
        public void Unregister(CountdownTimer timer)
        {
            if (timer == null)
            {
                throw new ArgumentNullException($"{nameof(timer)} can't be equal to null!");
            }

            timer.TimerFinished -= InvokeAction;
        }
        #endregion

        #region Private methods
        private void InvokeAction(object sender, TimerFinishedEventArgs e)
        {
            Console.WriteLine($"{GetType().Name}: ended up at {DateTime.Now:T}");
            _triggerResults.Add(GetInvokationResult(sender, e));
        }

        protected abstract string GetInvokationResult(object sender, TimerFinishedEventArgs e);
        #endregion
    }
}