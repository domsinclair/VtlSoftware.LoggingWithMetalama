namespace VtlSoftware.LoggedConsoleApp
{
    internal class StringStuff
    {
        #region Public Methods
        public bool LoginWithoutObfuscation(string username, string password)
        {
            try
            {
                if(username == "Dom" && password == "MySecretPassword")
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
