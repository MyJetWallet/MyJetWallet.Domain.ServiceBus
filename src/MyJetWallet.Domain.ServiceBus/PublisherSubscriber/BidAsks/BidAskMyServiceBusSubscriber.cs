using JetBrains.Annotations;
using MyJetWallet.Domain.Prices;
using MyJetWallet.Domain.ServiceBus.Serializers;
using MyServiceBus.TcpClient;

namespace MyJetWallet.Domain.ServiceBus.PublisherSubscriber.BidAsks
{
    [UsedImplicitly]
    public class BidAskMyServiceBusSubscriber : Subscriber<BidAsk>
    {
        public BidAskMyServiceBusSubscriber(MyServiceBusTcpClient client, string queueName, bool deleteOnDisconnect) :
            base(client, TopicNames.BidAsk, queueName, deleteOnDisconnect,
                bytes => bytes.ByteArrayToServiceBusContract<BidAsk>())
        {

        }
    }
}