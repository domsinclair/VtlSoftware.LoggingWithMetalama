using Metalama.Framework.Aspects;
using Metalama.Framework.Code.SyntaxBuilders;
using Metalama.Framework.Code;


namespace Vtl.LogToConsole
{
    [CompileTime]
    static class LogHelpers
    {
        #region Public Methods
        public static InterpolatedStringBuilder BuildInterpolatedString(bool includeOutParameters)
        {
            var stringBuilder = new InterpolatedStringBuilder();

            // Include the type and method name.
            stringBuilder.AddText(meta.Target.Type.ToDisplayString(CodeDisplayFormat.MinimallyQualified));
            stringBuilder.AddText(".");
            stringBuilder.AddText(meta.Target.Method.Name);
            stringBuilder.AddText("(");

            // Include a placeholder for each parameter.
            var i = meta.CompileTime(0);

            foreach (var p in meta.Target.Parameters)
            {
                var comma = i > 0 ? ", " : string.Empty;

                if (SensitiveParameterFilter.IsSensitive(p))
                {
                    // Do not log sensitive parameters.
                    stringBuilder.AddText($"{comma}{p.Name} = <redacted> ");
                }
                else if (p.RefKind == RefKind.Out && !includeOutParameters)
                {
                    // When the parameter is 'out', we cannot read the value.
                    stringBuilder.AddText($"{comma}{p.Name} = <out> ");
                }
                else
                {
                    // Otherwise, add the parameter value.
                    stringBuilder.AddText($"{comma}{p.Name} = {{");
                    stringBuilder.AddExpression(p.Value);
                    stringBuilder.AddText("}");
                }

                i++;
            }

            stringBuilder.AddText(")");

            return stringBuilder;
        }

        #endregion
    }
}
