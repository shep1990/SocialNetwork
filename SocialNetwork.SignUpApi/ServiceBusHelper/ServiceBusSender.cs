using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SocialNetwork.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.SignUpApi.ServiceBusHelper
{
    public class ServiceBusSender
    {
        private readonly TopicClient _topicClient;
        private readonly IConfiguration _configuration;
        private const string TOPIC_PATH = "profiletopic";

        public ServiceBusSender(IConfiguration configuration)
        {
            _configuration = configuration;
            _topicClient = new TopicClient(
              _configuration.GetConnectionString("ServiceBusConnectionString"),
              TOPIC_PATH);
        }

        public async Task SendMessage(SignUpModel payload)
        {
            string data = JsonConvert.SerializeObject(payload);
            Message message = new Message(Encoding.UTF8.GetBytes(data));

            await _topicClient.SendAsync(message);
        }
    }
}
