using Metalama.Framework.Fabrics;
using Vtl.LogToConsole;

namespace VtlSoftware.LoggedConsoleApp
{
    internal class Fabric : ProjectFabric
    {
        #region Public Methods

        public override void AmendProject(IProjectAmender amender) { FabricExtensions.LogAllPublicMethods(amender); }

        #endregion
    }
}
