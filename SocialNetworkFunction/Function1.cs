using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SocialNetwork.Library;
using SocialNetwork.Profile.Domain.Services;

namespace SocialNetworkFunction
{
    public class Function1
    {
        private readonly IProfileService _profileService;

        public Function1(IProfileService profileService)
        {
            _profileService = profileService;
        }


        [FunctionName("Function1")]
        public async Task Run([ServiceBusTrigger(
            "profiletopic",
            "profilesubscription",
            Connection = "ServiceBusConnectionString")]string message)
        {
            var payload = JsonConvert.DeserializeObject<SignUpModel>(message);
            await _profileService.SaveProfile(payload);          
        }
    }
}
