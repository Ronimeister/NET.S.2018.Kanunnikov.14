using System;

namespace TimerImitation
{
    /// <summary>
    /// Class that provides <see cref="EventArgs"/> argument type for <see cref="CountdownTimer"/>
    /// </summary>
    public class TimerFinishedEventArgs : EventArgs
    {
        /// <summary>
        /// return <see cref="DateTime"/> representation of invokation time
        /// </summary>
        public DateTime InvokationTime => DateTime.Now;
    }
}
