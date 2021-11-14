using System;
using Microsoft.Extensions.Configuration;

namespace Yunyun.Core.Services
{
    public static class ConfigurationService
    {
        public static string Token { get; set; }
        public static string Prefix { get; set; }
        public static string Version { get; set; }
        public static string GeniusToken { get; set; }

        private static readonly string ConfigPath = "configuration.yaml";

        public static void RunService()
        {
            try
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddYamlFile(ConfigPath)
                    .Build();

                Token = config["Token"];
                Prefix = config["Prefix"];
                Version = config["Version"];
                GeniusToken = config["GeniusToken"];
            }

            catch (Exception)
            {
                Console.WriteLine("Configuration could not be loaded! Exiting...");
                Environment.Exit(0);
            }
        }
    }
}