using Metalama.Logging.Console;

namespace VtlSoftware.LoggedConsoleApp
{
    internal class StringStuff
    {
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

        #endregion
    }
}
