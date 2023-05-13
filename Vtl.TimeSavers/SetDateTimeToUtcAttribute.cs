////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Vtl.TimeSavers\SetDateTimeToUtcAttribute.cs
//
// summary:	Implements the set date time to UTC attribute class
////////////////////////////////////////////////////////////////////////////////////////////////////

using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using System;

namespace Vtl.TimeSavers
{
    /// <summary>
    /// Ab Attribute to set The entered date time to utc.
    /// </summary>
    [CompileTime]
    public class SetDateTimeToUtcAttribute : FieldOrPropertyAspect
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Sets the Date/Time of the override property.
        /// </summary>
        ///
        /// <value>The override property.</value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [Template]
        private DateTime OverrideProperty { set => meta.Target.FieldOrProperty.Value = value.ToUniversalTime(); }

        #region Public Methods
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
/// Builds an aspect.
/// </summary>
        ///
        /// <param name="builder">The builder.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override void BuildAspect(IAspectBuilder<IFieldOrProperty> builder)
        { builder.Advice.Override(builder.Target, nameof(this.OverrideProperty)); }

        #endregion
    }
}
