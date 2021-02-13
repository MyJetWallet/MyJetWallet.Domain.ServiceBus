using JetBrains.Annotations;
using MyJetWallet.Domain.ServiceBus.Models;
using MyJetWallet.Domain.ServiceBus.Serializers;
using MyServiceBus.TcpClient;

namespace MyJetWallet.Domain.ServiceBus.PublisherSubscriber.Registrations
{
    [UsedImplicitly]
    public class ClientRegistrationServiceBusSubscriber : Subscriber<ClientRegistrationMessage>
    {
        public ClientRegistrationServiceBusSubscriber(MyServiceBusTcpClient client, string queueName, bool deleteOnDisconnect) :
            base(client, TopicNames.ClientRegistration, queueName, deleteOnDisconnect,
                bytes => bytes.ByteArrayToServiceBusContract<ClientRegistrationMessage>())
        {

        }
    }
}