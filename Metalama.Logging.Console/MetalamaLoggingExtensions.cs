using Metalama.Framework.Aspects;
using Metalama.Framework.Project;

namespace Metalama.Logging.Console
{
    [CompileTime]
    public static class MetalamaLoggingExtensions
    {
        #region Public Methods

        public static LoggingOptions LoggingOptions(this IProject project) => project.Extension<LoggingOptions>();

        #endregion
    }
}
