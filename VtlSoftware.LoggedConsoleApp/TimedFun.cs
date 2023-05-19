
using System.Diagnostics;
using Vtl.LogToConsole;

namespace VtlSoftware.LoggedConsoleApp
{
    partial class TimedFun
    {
        #region Public Methods
        [TimedLogMethod]
        public void Delay()
        {
            Stopwatch watch = Stopwatch.StartNew();
            Thread.Sleep(2000);
            watch.Stop();
        }

        #endregion
    }
}
