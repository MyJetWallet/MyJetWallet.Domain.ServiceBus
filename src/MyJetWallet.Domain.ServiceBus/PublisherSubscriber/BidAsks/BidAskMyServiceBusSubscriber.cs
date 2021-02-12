using JetBrains.Annotations;
using MyJetWallet.Domain.MyServiceBus.Serializers;
using MyJetWallet.Domain.Prices;
using MyServiceBus.TcpClient;

namespace MyJetWallet.Domain.MyServiceBus.PublisherSubscriber.BidAsks
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