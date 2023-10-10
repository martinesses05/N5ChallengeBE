using Microsoft.Extensions.Configuration;

namespace N5.Permissions.Core.Contracts
{
    public static class AppSettings
    {
        public static Settings Settings { get; set; }     
    }

    public class Settings
    {
        public string ConnectionString { get; set; }        
    }
}
