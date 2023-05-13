using Vtl.TimeSavers;

namespace VtlSoftware.LoggedConsoleApp
{
    internal class DateTimeStuff
    {
        #region Fields

        private DateTime timeNow;

        #endregion

        #region Public Methods
        public void SaveAndReportTime(DateTime timeToSave)
        {
            TimeNow = timeToSave;
            Console.WriteLine($"The saved time is {TimeNow}");
        }

        #endregion

        #region Public Properties
        [SetDateTimeToUtc]
        public DateTime TimeNow { get => timeNow; set => timeNow = value; }

        #endregion
    }
}
