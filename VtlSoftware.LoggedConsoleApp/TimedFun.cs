using System.Diagnostics;
using Vtl.LogToConsole;

namespace VtlSoftware.LoggedConsoleApp
{
    internal partial class TimedFun
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
