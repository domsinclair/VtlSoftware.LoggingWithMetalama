using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using System.Linq;

namespace Metalama.Logging.Console
{
    [CompileTime]
    internal static class SensitiveParameterFilter
    {

        #region Public Methods
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
