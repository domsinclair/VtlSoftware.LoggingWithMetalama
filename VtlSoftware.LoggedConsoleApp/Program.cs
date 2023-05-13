using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Vtl.LogToConsole;

namespace VtlSoftware.LoggedConsoleApp
{
    internal partial class Program
    {
        #region Private Methods

        [DoNotLogMethod]
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddLogging(builder => builder.AddConsole().SetMinimumLevel(LogLevel.Trace))
            .AddSingleton<Calculator>()
            .AddSingleton<StringStuff>()
            .AddSingleton<TimedFun>()
            .AddSingleton<DateTimeStuff>()
            .BuildServiceProvider();

            var calculator = serviceProvider.GetService<Calculator>()!;

            try
            {
                calculator.Add(1, 1);
                calculator.Subtract(1, 1);
                calculator.Multiply(1, 1);
                calculator.Divide(1, 1);
            } catch
            {
            }

            var stringStuff = serviceProvider.GetService<StringStuff>()!;

            try
            {
                Console.WriteLine(stringStuff.LoginWithoutObfuscation("Dom", "MySecretPassword").ToString());
                Console.WriteLine(stringStuff.LoginWithObfuscation("Dom", "MySecretPassword").ToString());
                stringStuff.PlayWithRougeStrings("MySecretName   ");
            } catch
            {
            }

            var times = serviceProvider.GetService<TimedFun>()!;
            try
            {
                times.Delay();
            } catch
            {
            }

            var dt = serviceProvider.GetService<DateTimeStuff>()!;
            try
            {
                dt.SaveAndReportTime(DateTime.Now);
            } catch
            {
            }
        }

        #endregion
    }
}