using Metalama.Framework.Project;
using System;

namespace Metalama.Logging.Console
{
    public class LoggingOptions : ProjectExtension
    {
        #region Fields

        private string[] sensitiveData = null;

        #endregion

        #region Public Methods
        public override void Initialize(IProject project, bool isReadOnly)
        {
            base.Initialize(project, isReadOnly);

            if(project.TryGetProperty("SensitiveData", out var propertyValue))
            {
                //do stuff to convert propertyValue to string array here then we'd set sensitiveData
                //this.sensitiveData = propertyValue;
            }
        }

        #endregion

        #region Public Properties
        public string[] SensitiveData
        {
            get => this.sensitiveData;

            set
            {
                if(this.IsReadOnly)
                {
                    throw new InvalidOperationException();
                }
                this.sensitiveData = value;
            }
        }

        #endregion
    }
}
