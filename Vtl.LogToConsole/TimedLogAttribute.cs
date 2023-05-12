using Metalama.Extensions.DependencyInjection;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Metalama.Framework.Code.SyntaxBuilders;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace Vtl.LogToConsole
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Attribute for timed log.
    /// </summary>
    ///
    /// <seealso cref="OverrideMethodAspect"/>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class TimedLogAttribute : OverrideMethodAspect
    {
        #region Fields
        [IntroduceDependency]
        private readonly ILogger logger;

        #endregion

        #region Public Methods
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

            Stopwatch watch = Stopwatch.StartNew();

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
            } finally
            {
                watch.Stop();
                var elapsedMessage = LogHelpers.BuildInterpolatedString(false);
                elapsedMessage.AddText(" elapsed: ");
                elapsedMessage.AddExpression(watch.ElapsedMilliseconds);
                elapsedMessage.AddText("ms");
                logger.LogInformation((string)elapsedMessage.ToValue());
            }
        }

        #endregion
    }
}
