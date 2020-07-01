using Microsoft.AspNetCore.SignalR;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SocialNetwork.Library;
using SocialNetwork.Notification.Domain.Services;
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
        private readonly INotificationService _notificationService;

        public ServiceBusConsumer(
            IConfiguration configuration,
            IHubContext<NotificationsHub, INotificationHub> notificationsHubContext,
            INotificationService notificationService
        )
        {
            _configuration = configuration;
            _subscriptionClient = new SubscriptionClient(_configuration.GetConnectionString("ServiceBusConnectionString"), TOPIC_PATH, SUBSCRIPTION_NAME);
            _notificationsHubContext = notificationsHubContext;
            _notificationService = notificationService;
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

            var notification = new NotificationModel
            {
                UserId = myPayload.UserId,
                NotificationMessage = myPayload.Status,
                UserName = myPayload.Name
            };

            await _notificationService.AddNotification(notification);

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
