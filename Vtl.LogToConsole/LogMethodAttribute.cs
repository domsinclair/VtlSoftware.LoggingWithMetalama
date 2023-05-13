////////////////////////////////////////////////////////////////////////////////////////////////////
// <summary>Implements the log attribute class</summary>
////////////////////////////////////////////////////////////////////////////////////////////////////

using Metalama.Extensions.DependencyInjection;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Metalama.Framework.Code.SyntaxBuilders;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Vtl.LogToConsole
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Attribute for log. This is the main Log Attrute that provides a set of basic logging instructions to a method.
    /// </summary>
    ///
    /// <seealso cref="OverrideMethodAspect"/>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class LogMethodAttribute : OverrideMethodAspect
    {
        #region Fields
        /// <summary>
        /// (Immutable) The logger.
        /// </summary>
        [IntroduceDependency]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private readonly ILogger logger;

        #endregion


#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


        #region Public Methods
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
/// Builds an aspect.///
/// </summary>
        ///
        /// <param name="builder">The builder.</param>
        ///
        /// <seealso cref="Metalama.Framework.Aspects.OverrideMethodAspect.BuildAspect(IAspectBuilder{IMethod})"/>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override void BuildAspect(IAspectBuilder<IMethod> builder)
        {
            if(!(builder.Target.Attributes.OfAttributeType(typeof(DoNotLogMethodAttribute)).Any() ||
                builder.Target.Attributes.OfAttributeType(typeof(TimedLogMethodAttribute)).Any()))
            {
                builder.Advice.Override(builder.Target, nameof(this.OverrideMethod));
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Default template of the new method implementation.
        /// </summary>
        ///
        /// <returns>A dynamic?</returns>
        ///
        /// <seealso cref="Metalama.Framework.Aspects.OverrideMethodAspect.OverrideMethod()"/>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override dynamic? OverrideMethod()
        {
            // Determine if tracing is enabled.
            var isTracingEnabled = logger.IsEnabled(LogLevel.Trace);

            // Write entry message.
            if(isTracingEnabled)
            {
                var entryMessage = LogHelpers.BuildInterpolatedString(false);
                entryMessage.AddText(" started.");
                logger.LogTrace((string)entryMessage.ToValue());
            }

            try
            {
                // Invoke the method and store the result in a variable.
                var result = meta.Proceed();

                if(isTracingEnabled)
                {
                    // Display the success message. The message is different when the method is void.
                    var successMessage = LogHelpers.BuildInterpolatedString(true);

                    if(meta.Target.Method.ReturnType.Is(typeof(void)))
                    {
                        // When the method is void, display a constant text.
                        successMessage.AddText(" succeeded.");
                    } else
                    {
                        // When the method has a return value, add it to the message.
                        successMessage.AddText(" returned ");
                        successMessage.AddExpression(result);
                        successMessage.AddText(".");
                    }

                    logger.LogTrace((string)successMessage.ToValue());
                }

                return result;
            } catch(Exception e) when (logger.IsEnabled(LogLevel.Warning))
            {
                // Display the failure message.
                var failureMessage = LogHelpers.BuildInterpolatedString(false);
                failureMessage.AddText(" failed: ");
                failureMessage.AddExpression(e.Message);
                logger.LogWarning((string)failureMessage.ToValue());

                throw;
            }
        }

        #endregion
    }
}
