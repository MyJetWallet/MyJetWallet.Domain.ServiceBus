using JetBrains.Annotations;
using MyJetWallet.Domain.ServiceBus.Models;
using MyJetWallet.Domain.ServiceBus.Serializers;
using MyServiceBus.Abstractions;
using MyServiceBus.TcpClient;

namespace MyJetWallet.Domain.ServiceBus.PublisherSubscriber.Registrations
{
    [UsedImplicitly]
    public class ClientRegistrationServiceBusSubscriber : Subscriber<ClientRegistrationMessage>
    {
        public ClientRegistrationServiceBusSubscriber(MyServiceBusTcpClient client, string queueName, TopicQueueType queryType, bool batchSubscribe) :
            base(client, TopicNames.ClientRegistration, queueName, queryType,
                bytes => bytes.ByteArrayToServiceBusContract<ClientRegistrationMessage>(), batchSubscribe)
        {

        }
    }
}