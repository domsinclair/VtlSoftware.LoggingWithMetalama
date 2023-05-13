using Vtl.LogToConsole;
using Vtl.TimeSavers;

namespace VtlSoftware.LoggedConsoleApp
{
    internal partial class StringStuff
    {
        #region Fields

        private string? myPassword;

        #endregion

        #region Private Methods
        private int GetStringCount(string stringToCount) { return stringToCount.Length; }

        #endregion

        #region Public Methods
        public bool LoginWithObfuscation(string username, [NotLogged]string userSecret)
        {
            try
            {
                if(username == "Dom" && userSecret == "MySecretPassword")
                    return true;
                else
                    return false;
            } catch(Exception)
            {
                return false;
            }
        }

        public bool LoginWithoutObfuscation(string username, string userSecret)
        {
            try
            {
                if(username == "Dom" && userSecret == "MySecretPassword")
                    return true;
                else
                    return false;
            } catch(Exception)
            {
                return false;
            }
        }

        public void PlayWithRougeStrings(string stringToTrim)
        {
            Console.WriteLine($"This is the sting that was passed: {stringToTrim}");
            Console.WriteLine(
                $"This is the character count of the string that was passed: {GetStringCount(stringToTrim)}.");
            Console.WriteLine("Saving String as MyPassword");
            MyPassword = stringToTrim;
            Console.WriteLine(
                $"This is the Character count of the string once it has been saved as MyPassword: {GetStringCount(MyPassword)}.");
        }

        #endregion

        #region Public Properties
        [TrimString]
        public string? MyPassword { get => myPassword; set => myPassword = value; }

        #endregion
    }
}
