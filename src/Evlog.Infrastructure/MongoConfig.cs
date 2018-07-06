namespace Evlog.Infrastructure
{
    public class MongoConfig
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public bool UseAuthentication { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int ConnectTimeout { get; set; } = 1000;
        public string ConnectionString
        {
            get
            {
                if(UseAuthentication)
                    return $"mongodb://{Username}:{Password}@{Host}:{Port}?connectTimeoutMS={ConnectTimeout}";
                return $"mongodb://{Host}:{Port}?connectTimeoutMS={ConnectTimeout}";
            }
        }

        public string Database { get; set; }
    }
}
