﻿namespace SearchEngine.LoggerAPI.Infrastructure.Client.Database
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
