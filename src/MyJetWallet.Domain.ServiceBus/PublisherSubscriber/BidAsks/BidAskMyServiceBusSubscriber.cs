using JetBrains.Annotations;
using MyJetWallet.Domain.Prices;
using MyJetWallet.Domain.ServiceBus.Serializers;
using MyServiceBus.Abstractions;
using MyServiceBus.TcpClient;

namespace MyJetWallet.Domain.ServiceBus.PublisherSubscriber.BidAsks
{
    [UsedImplicitly]
    public class BidAskMyServiceBusSubscriber : Subscriber<BidAsk>
    {
        public BidAskMyServiceBusSubscriber(MyServiceBusTcpClient client, string queueName, TopicQueueType queryType, bool batchSubscribe) :
            base(client, TopicNames.BidAsk, queueName, queryType,
                bytes => bytes.ByteArrayToServiceBusContract<BidAsk>(), batchSubscribe)
        {

        }
    }
}