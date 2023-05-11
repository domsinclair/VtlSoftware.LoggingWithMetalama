using Metalama.Logging.Console;
using System.Diagnostics;

namespace VtlSoftware.LoggedConsoleApp
{
    internal class TimedFun
    {
        #region Public Methods

        [TimedLog]
        public void Delay()
        {
            Stopwatch watch = Stopwatch.StartNew();
            watch.Start();
            Thread.Sleep(2000);
            watch.Stop();
        }

        #endregion
    }
}
