using System;

namespace Vtl.LogToConsole
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Attribute for no log. This class cannot be inherited. Add this attribute to methods for which logging is not
    /// required.
    /// </summary>
    ///
    /// <seealso cref="Attribute"/>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [AttributeUsage(AttributeTargets.Method)]
    public sealed class NoLogAttribute : Attribute
    {
    }
}
