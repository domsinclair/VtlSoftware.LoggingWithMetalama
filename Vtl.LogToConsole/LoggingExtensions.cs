////////////////////////////////////////////////////////////////////////////////////////////////////
// <summary>Implements the logging extensions class</summary>
////////////////////////////////////////////////////////////////////////////////////////////////////

using Metalama.Framework.Aspects;
using Metalama.Framework.Project;

namespace Vtl.LogToConsole
{
    /// <summary>
    /// A logging extensions.
    /// </summary>
    [CompileTime]
    public static class LoggingExtensions
    {
        #region Public Methods
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
/// An IProject extension method that Logging options.
/// </summary>
        ///
        /// <param name="project">The project to act on.</param>
        ///
        /// <returns>The LoggingOptions.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static LoggingOptions LoggingOptions(this IProject project) => project.Extension<LoggingOptions>();

        #endregion
    }
}
