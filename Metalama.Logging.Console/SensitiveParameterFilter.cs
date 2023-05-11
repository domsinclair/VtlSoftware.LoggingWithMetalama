using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using System.Linq;

namespace Metalama.Logging.Console
{
    [CompileTime]
    internal static class SensitiveParameterFilter
    {
        #region Fields

        private static readonly string[] _sensitiveNames = new[] { "password", "credential", "pwd" };

        #endregion

        #region Public Methods
        public static bool IsSensitive(IParameter parameter)
        {
            if(parameter.Attributes.OfAttributeType(typeof(NotLoggedAttribute)).Any())
            {
                return true;
            }

            if(_sensitiveNames.Any(n => parameter.Name.ToLowerInvariant().Contains(n)))
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}
