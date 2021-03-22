using System.Threading.Tasks;
using DotNetCoreDecorators;
using JetBrains.Annotations;
using MyJetWallet.Domain.ServiceBus.Models;
using MyJetWallet.Domain.ServiceBus.Serializers;
using MyServiceBus.TcpClient;

namespace MyJetWallet.Domain.ServiceBus.PublisherSubscriber.Registrations
{
    [UsedImplicitly]
    public class ClientRegistrationServiceBusPublisher : IPublisher<ClientRegistrationMessage>
    {
        private readonly MyServiceBusTcpClient _client;

        public ClientRegistrationServiceBusPublisher(MyServiceBusTcpClient client)
        {
            _client = client;
            _client.CreateTopicIfNotExists(TopicNames.ClientRegistration);
        }

        public async ValueTask PublishAsync(ClientRegistrationMessage valueToPublish)
        {
            var bytesToSend = valueToPublish.ServiceBusContractToByteArray();
            await _client.PublishAsync(TopicNames.ClientRegistration, bytesToSend, true);
        }
    }
}