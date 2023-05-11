using System;

namespace Metalama.Logging.Console
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class NoLogAttribute : Attribute
    {
    }
}
