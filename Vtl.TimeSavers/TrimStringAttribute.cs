﻿////////////////////////////////////////////////////////////////////////////////////////////////////
// <summary>Implements the trim string attribute class</summary>
////////////////////////////////////////////////////////////////////////////////////////////////////

using Metalama.Framework.Aspects;
using Metalama.Framework.Code;

namespace Vtl.TimeSavers
{
    /// <summary>
    /// Attribute to trim a string. When applied to a property it will trim any string that is passed into it.
    /// </summary>
    public class TrimStringAttribute : FieldOrPropertyAspect
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Sets the override property.
        /// </summary>
        ///
        /// <value>The override property.</value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [Template]
        private string OverrideProperty { set => meta.Target.FieldOrProperty.Value = value?.Trim(); }

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
/// Builds an eligibility.
/// </summary>
        ///
        /// <param name="builder">The builder.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //public override void BuildEligibility(IEligibilityBuilder<IFieldOrProperty> builder)
        //{
        //    base.BuildEligibility(builder);

        //    builder.MustBeOfType(typeof(string));
        //}
    }
}
