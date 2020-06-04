using Microsoft.AspNetCore.SignalR;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SocialNetwork.Library;
using SocialNetwork.NotificationsApi.Notifications;
using SocialNetwork.WebApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.NotificationsApi.ServiceBusHelper
{
    public class ServiceBusConsumer : IServiceBusConsumer
    {
        private readonly IConfiguration _configuration;
        private readonly SubscriptionClient _subscriptionClient;
        private const string TOPIC_PATH = "statustopic";
        private const string SUBSCRIPTION_NAME = "statusSubscription";
        IHubContext<NotificationsHub, INotificationHub> _notificationsHubContext;

        public ServiceBusConsumer(
            IConfiguration configuration,
            IHubContext<NotificationsHub, INotificationHub> notificationsHubContext
        )
        {
            _configuration = configuration;
            _subscriptionClient = new SubscriptionClient(_configuration.GetConnectionString("ServiceBusConnectionString"), TOPIC_PATH, SUBSCRIPTION_NAME);
            _notificationsHubContext = notificationsHubContext;
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
            var myPayload = JsonConvert.DeserializeObject<StatusModel>(Encoding.UTF8.GetString(message.Body));

            await _notificationsHubContext.Clients.All.BroadcastMessage("Status", myPayload.Status);

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
