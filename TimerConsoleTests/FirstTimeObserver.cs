using TimerImitation;

namespace TimerConsoleTests
{
    /// <summary>
    /// Observer class for <see cref="CountdownTimer"/>
    /// </summary>
    class FirstTimeObserver : AbstractTimeObserver
    {
        protected override string GetInvokationResult(object sender, TimerFinishedEventArgs e)
            => $"{nameof(FirstTimeObserver)}'s timer is up at: {e.InvokationTime:T}";
    }
}
