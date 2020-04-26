using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SocialNetwork.Library;
using SocialNetwork.Profile.Domain.Services;
using SocialNetwork.WebApiClient;

namespace SocialNetworkFunction
{
    public class Function1
    {
        private readonly IProfileApiClient _profileApiClient;

        public Function1(IProfileApiClient profileApiClient)
        {
            _profileApiClient = profileApiClient;
        }


        [FunctionName("Function1")]
        public async Task Run([ServiceBusTrigger(
            "profiletopic",
            "profilesubscription",
            Connection = "ServiceBusConnectionString")]string message)
        {
            var payload = JsonConvert.DeserializeObject<SignUpModel>(message);
            await _profileApiClient.CreateProfile(payload);        
        }
    }
}
