using Metalama.Framework.Project;
using System;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Net;

namespace Metalama.Logging.Console
{
    public class LoggingOptions : ProjectExtension
    {
        #region Fields

        private ImmutableHashSet<string> sensitiveData = ImmutableHashSet<string>.Empty;

        #endregion

        #region Public Methods
        public override void Initialize(IProject project, bool isReadOnly)
        {
            base.Initialize(project, isReadOnly);

            var builder = ImmutableHashSet.CreateBuilder(StringComparer.OrdinalIgnoreCase);

            void AddKeywords(string line)
            {
                foreach (var keyword in line.Split(new[]
                             { ' ', ',', ';' }).Select( x => x.Trim()).Where(x=>!string.IsNullOrEmpty(x)))
                {
                    builder.Add(keyword);
                }
            }

            if(project.TryGetProperty("SensitiveData", out var sensitiveDataPropertyValue))
            {
                AddKeywords(sensitiveDataPropertyValue);
             
            }
            
            if(project.TryGetProperty("SensitiveDataFile", out var sensitiveDataFile))
            {
                foreach (var line in File.ReadAllLines(sensitiveDataFile))
                {
                    AddKeywords(line);
                }
            }
            
            sensitiveData = builder.ToImmutable();
        }

        #endregion

        #region Public Properties
        public ImmutableHashSet<string> SensitiveData
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
