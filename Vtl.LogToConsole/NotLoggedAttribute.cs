using System;

namespace Vtl.LogToConsole
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Attribute for not logged. This class cannot be inherited. Add this attribute to Method parameters or Return
    /// values that should not be logged in order to maintain confidentiality.
    /// </summary>
    ///
    /// <seealso cref="Attribute"/>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    public sealed class NotLoggedAttribute : Attribute
    {
    }
}
