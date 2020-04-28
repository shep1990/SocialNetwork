using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.WebApiClient;
using System;
using System.IO;

[assembly: FunctionsStartup(typeof(SocialNetworkFunction.Startup))]

namespace SocialNetworkFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var apiEndpoint = config.GetSection("AuthApi").Value;

            builder.Services.AddTransient(x => ProfileApiFactory.Create(apiEndpoint));
        }
    }
}
