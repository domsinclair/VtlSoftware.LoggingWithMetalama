using Metalama.Framework.Aspects;
using Metalama.Framework.Project;

namespace Vtl.LogToConsole
{
    [CompileTime]
    public static class LoggingExtensions
    {
        #region Public Methods

        public static LoggingOptions LoggingOptions(this IProject project) => project.Extension<LoggingOptions>();

        #endregion
    }
}
