using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.WebApiClient;

[assembly: FunctionsStartup(typeof(SocialNetworkFunction.Startup))]

namespace SocialNetworkFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient(x => ProfileApiFactory.Create("http://profileApi.com"));

        }
    }
}
