////////////////////////////////////////////////////////////////////////////////////////////////////
// <summary>Implements the fabric extensions class</summary>
////////////////////////////////////////////////////////////////////////////////////////////////////

using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Metalama.Framework.Fabrics;

namespace Vtl.LogToConsole
{
    ///---- FabricExtensions   (Class) ----
    ///
    /// <summary>
    /// Fabric extensions.
    /// </summary>
    ///
    /// <remarks>
    /// A number of extension methods to provide common scenarios for adding the [LogMethod] attribute to class methods
    /// automatically.
    /// </remarks>
    ///-------------------------------------------------------------------------------------------------

    [CompileTime]
    public static class FabricExtensions
    {
        #region Public Methods

        ///---- LogAllMethods   (Method) ----
        ///
        /// <summary>
        /// An IProjectAmender extension method that logs all methods.
        /// </summary>
        ///
        /// <remarks>Specifically excludes methods from Static classes.</remarks>
        ///
        /// <param name="amender">The amender to act on.</param>
        ///-------------------------------------------------------------------------------------------------

        public static void LogAllMethods(this IProjectAmender amender)
        {
            amender.Outbound
            .SelectMany(compilation => compilation.AllTypes)
            .Where(type => !type.IsStatic)
            .SelectMany(type => type.Methods)
            .Where(method => method.Name != "ToString")
            .AddAspectIfEligible<LogMethodAttribute>();
        }

        ///---- LogAllPublicAndPrivateMethods   (Method) ----
        ///
        /// <summary>
        /// An IProjectAmender extension method that logs all public and private methods.
        /// </summary>
        ///
        /// <remarks>Specifically excludes methods from Static classes.</remarks>
        ///
        /// <param name="amender">The amender to act on.</param>
        ///-------------------------------------------------------------------------------------------------

        public static void LogAllPublicAndPrivateMethods(this IProjectAmender amender)
        {
            amender.Outbound
            .SelectMany(compilation => compilation.AllTypes)
            .Where(type => type.Accessibility is Accessibility.Public or Accessibility.Internal && !type.IsStatic)
            .SelectMany(type => type.Methods)
            .Where(
                method => method.Accessibility is Accessibility.Public or Accessibility.Private &&
                    method.Name != "ToString")
            .AddAspectIfEligible<LogMethodAttribute>();
        }

        ///---- LogAllPublicMethods   (Method) ----
        ///
        /// <summary>
        /// An IProjectAmender extension method that logs all public methods.
        /// </summary>
        ///
        /// <remarks>Specifically excludes methods from Static classes.</remarks>
        ///
        /// <param name="amender">The amender to act on.</param>
        ///-------------------------------------------------------------------------------------------------

        public static void LogAllPublicMethods(this IProjectAmender amender)
        {
            amender.Outbound
            .SelectMany(compilation => compilation.AllTypes)
            .Where(type => type.Accessibility is Accessibility.Public or Accessibility.Internal && !type.IsStatic)
            .SelectMany(type => type.Methods)
            .Where(method => method.Accessibility is Accessibility.Public && method.Name != "ToString")
            .AddAspectIfEligible<LogMethodAttribute>();
        }

        #endregion
    }
}
