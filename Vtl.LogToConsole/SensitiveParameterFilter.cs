////////////////////////////////////////////////////////////////////////////////////////////////////
// <summary>Implements the sensitive parameter filter class</summary>
////////////////////////////////////////////////////////////////////////////////////////////////////

using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using System.Linq;

namespace Vtl.LogToConsole
{
    /// <summary>
    /// A sensitive parameter filter.
    /// </summary>
    [CompileTime]
    internal static class SensitiveParameterFilter
    {
        #region Public Methods
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
/// Query if 'parameter' is sensitive.
/// </summary>
        ///
        /// <param name="parameter">The parameter.</param>
        ///
        /// <returns>True if sensitive, false if not.</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsSensitive(IParameter parameter)
        {
            if(parameter.Attributes.OfAttributeType(typeof(NotLoggedAttribute)).Any())
            {
                return true;
            }

            var options = parameter.Compilation.Project.LoggingOptions();

            return options.SensitiveData.Contains(parameter.Name);
        }

        #endregion
    }
}
