using TimerImitation;

namespace TimerConsoleTests
{
    /// <summary>
    /// Observer class for <see cref="CountdownTimer"/>
    /// </summary>
    class SecondTimeObserver : AbstractTimeObserver
    {
        protected override string GetInvokationResult(object sender, TimerFinishedEventArgs e)
            => $"{nameof(SecondTimeObserver)}'s timer is up at: {e.InvokationTime:T}";
    }
}
