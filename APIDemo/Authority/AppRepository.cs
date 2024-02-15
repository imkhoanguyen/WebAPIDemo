namespace APIDemo.Authority
{
    public class AppRepository
    {
        private static List<Application> _appliactions = new List<Application>()
        {
            new Application
            {
                ApplicationId = 1,
                ApplicationName = "MVCWebApp",
                ClientId = "KhoaNguyen-SQLEXPRESS",
                Secret = "KhoaNguyen-SQLEXPRESS",
                Scope = "read,write"
            }
        };

        public static bool Authenticate(string clientId, string secret)
        {
            return _appliactions.Any(x => x.ClientId == clientId && x.Secret == secret);
        }

        public static Application? GetApplicationByClientId(string clientId)
        {
            return _appliactions.FirstOrDefault(x => x.ClientId == clientId);
        }
    }
}
