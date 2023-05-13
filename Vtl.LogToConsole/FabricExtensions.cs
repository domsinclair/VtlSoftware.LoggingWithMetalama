////////////////////////////////////////////////////////////////////////////////////////////////////
// <summary>Implements the fabric extensions class</summary>
////////////////////////////////////////////////////////////////////////////////////////////////////

using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Metalama.Framework.Fabrics;

namespace Vtl.LogToConsole
{
    /// <summary>
    /// A fabric extensions.  A set of extension methods that provide a number of common scenarios for adding logging
    /// attributes to  a project automatically.
    /// </summary>
    [CompileTime]
    public static class FabricExtensions
    {
        #region Public Methods
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
/// An IProjectAmender extension method that logs all methods.
/// </summary>
        ///
        /// <param name="amender">The amender to act on.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void LogAllMethods(this IProjectAmender amender)
        {
            amender.Outbound
            .SelectMany(compilation => compilation.AllTypes)
            .Where(type => type.Accessibility is Accessibility.Public or Accessibility.Internal)
            .SelectMany(type => type.Methods)
            .Where(method => method.Accessibility is Accessibility.Undefined && method.Name != "ToString")
            .AddAspectIfEligible<LogMethodAttribute>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
/// An IProjectAmender extension method that logs all public and private methods.
/// </summary>
        ///
        /// <param name="amender">The amender to act on.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void LogAllPublicAndPrivateMethods(this IProjectAmender amender)
        {
            amender.Outbound
            .SelectMany(compilation => compilation.AllTypes)
            .Where(type => type.Accessibility is Accessibility.Public or Accessibility.Internal)
            .SelectMany(type => type.Methods)
            .Where(
                method => method.Accessibility is Accessibility.Public or Accessibility.Private &&
                    method.Name != "ToString")
            .AddAspectIfEligible<LogMethodAttribute>();
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// An IProjectAmender extension method that logs all public methods.
        /// </summary>
        ///
        /// <param name="amender">The amender to act on.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void LogAllPublicMethods(this IProjectAmender amender)
        {
            amender.Outbound
            .SelectMany(compilation => compilation.AllTypes)
            .Where(type => type.Accessibility is Accessibility.Public or Accessibility.Internal)
            .SelectMany(type => type.Methods)
            .Where(method => method.Accessibility is Accessibility.Public && method.Name != "ToString")
            .AddAspectIfEligible<LogMethodAttribute>();
        }

        #endregion
    }
}
