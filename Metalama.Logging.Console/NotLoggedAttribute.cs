using System;

namespace Metalama.Logging.Console
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    public sealed class NotLoggedAttribute : Attribute
    {
    }
}
