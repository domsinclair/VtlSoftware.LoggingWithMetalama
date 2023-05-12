////////////////////////////////////////////////////////////////////////////////////////////////////
// <summary>Implements the log fabric class</summary>
////////////////////////////////////////////////////////////////////////////////////////////////////

using Metalama.Framework.Code;
using Metalama.Framework.Fabrics;

namespace Vtl.LogToConsole
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// A log fabric.
    /// </summary>
    ///
    /// <seealso cref="TransitiveProjectFabric"/>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class LogFabric : TransitiveProjectFabric
    {
        #region Public Methods
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
/// The user can implement this method to analyze types in the current project, add aspects, and report or
/// suppress diagnostics.
/// </summary>
        ///
        /// <param name="amender">The amender.</param>
        ///
        /// <seealso cref="Metalama.Framework.Fabrics.ProjectFabric.AmendProject(IProjectAmender)"/>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override void AmendProject(IProjectAmender amender)
        {
            amender.Outbound
            .SelectMany(compilation => compilation.AllTypes)
            .Where(type => type.Accessibility is Accessibility.Public or Accessibility.Internal)
            .SelectMany(type => type.Methods)
            .Where(
                method => method.Accessibility is Accessibility.Public or Accessibility.Private &&
                    method.Name != "ToString")
            .AddAspectIfEligible<LogAttribute>();
        }

        #endregion
    }
}

