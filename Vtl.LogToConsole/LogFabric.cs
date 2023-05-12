using Metalama.Framework.Code;
using Metalama.Framework.Fabrics;

namespace Vtl.LogToConsole
{
    public class LogFabric : TransitiveProjectFabric
    {
        #region Public Methods
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

