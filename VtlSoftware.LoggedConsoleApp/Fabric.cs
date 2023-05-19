using Metalama.Framework.Fabrics;
using Vtl.LogToConsole;

namespace VtlSoftware.LoggedConsoleApp
{
    internal class Fabric : ProjectFabric
    {
        public override void AmendProject(IProjectAmender amender) 
        {     
            amender.LogAllPublicMethods();
        }
    }
}
