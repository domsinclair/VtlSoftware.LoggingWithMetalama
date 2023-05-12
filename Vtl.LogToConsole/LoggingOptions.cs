////////////////////////////////////////////////////////////////////////////////////////////////////
// <summary>Implements the logging options class</summary>
////////////////////////////////////////////////////////////////////////////////////////////////////

using Metalama.Framework.Project;
using System;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace Vtl.LogToConsole
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// A logging options.
    /// </summary>
    ///
    /// <seealso cref="ProjectExtension"/>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class LoggingOptions : ProjectExtension
    {
        #region Fields

        /// <summary>
        /// Information describing the sensitive.
        /// </summary>
        private ImmutableHashSet<string> sensitiveData = ImmutableHashSet<string>.Empty;

        #endregion

        #region Public Methods
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
/// Initializes the object from project properties.
/// </summary>
        ///
        /// <param name="project">
/// The project to which the new <see cref="T:Metalama.Framework.Project.ProjectExtension"/> belongs.
/// </param>
        /// <param name="isReadOnly">
/// A value indicating whether the project data is already read-only. If <c>false</c>, the project data can
/// still be modified by project fabrics, after which the <see
/// cref="M:Metalama.Framework.Project.ProjectExtension.MakeReadOnly"/> method will be called.
/// </param>
        ///
        /// <seealso cref="Metalama.Framework.Project.ProjectExtension.Initialize(IProject,bool)"/>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override void Initialize(IProject project, bool isReadOnly)
        {
            base.Initialize(project, isReadOnly);

            var builder = ImmutableHashSet.CreateBuilder(StringComparer.OrdinalIgnoreCase);

            void AddKeywords(string line)
            {
                foreach(var keyword in line.Split(new[] { ' ', ',', ';' }).Select(x => x.Trim()).Where(
                    x => !string.IsNullOrEmpty(x)))
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
                // TODO: this data is cached, and no caching invalidation mechanism is implemented for external files.
                // Therefore, the user needs to restart the IDE after changing that file.
                foreach(var line in File.ReadAllLines(sensitiveDataFile))
                {
                    AddKeywords(line);
                }
            }

            sensitiveData = builder.ToImmutable();
        }

        #endregion

        #region Public Properties
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
/// Gets or sets information describing the sensitive.
/// </summary>
        ///
        /// <exception cref="InvalidOperationException">
/// Thrown when the requested operation is invalid.
/// </exception>
        ///
        /// <value>Information describing the sensitive.</value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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
