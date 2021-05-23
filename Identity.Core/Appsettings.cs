using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Core
{
    public partial class Appsettings
    {
        public Logging Logging { get; set; }

        public ConnectionStrings ConnectionStrings { get; set; }

        public string AllowedHosts { get; set; }

        public JwtSettings JwtSettings { get; set; }
    }

    public class JwtSettings
    {
        public string Issuer { get; set; }

        public string Secret { get; set; }

        public int ExpirationInDays { get; set; }
    }

    public partial class ConnectionStrings
    {
        public string API { get; set; }

        public string Identity { get; set; }
    }

    public partial class Logging
    {
        public LogLevel LogLevel { get; set; }
    }

    public partial class LogLevel
    {
        public string Default { get; set; }

        public string Microsoft { get; set; }

        public string MicrosoftHostingLifetime { get; set; }
    }
}
