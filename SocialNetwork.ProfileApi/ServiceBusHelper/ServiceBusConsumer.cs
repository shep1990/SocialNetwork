using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SocialNetwork.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.ProfileApi.ServiceBusHelper
{
    public class ServiceBusConsumer : IServiceBusConsumer
    {
        private readonly IConfiguration _configuration;
        private readonly SubscriptionClient _subscriptionClient;
        private const string TOPIC_PATH = "profiletopic";
        private const string SUBSCRIPTION_NAME = "profileSubscription";

        public ServiceBusConsumer(
            IConfiguration configuration        )
        {
            _configuration = configuration;
            _subscriptionClient = new SubscriptionClient(_configuration.GetConnectionString("ServiceBusConnectionString"), TOPIC_PATH, SUBSCRIPTION_NAME);
        }

        public void RegisterOnMessageHandlerAndReceiveMessages()
        {
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            _subscriptionClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
        }

        private async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            var myPayload = JsonConvert.DeserializeObject<SignUpModel>(Encoding.UTF8.GetString(message.Body));
            await _subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            return Task.CompletedTask;
        }

        public async Task CloseQueueAsync()
        {
            await _subscriptionClient.CloseAsync();
        }
    }
}
