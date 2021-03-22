using JetBrains.Annotations;
using MyJetWallet.Domain.Prices;
using MyJetWallet.Domain.ServiceBus.Serializers;
using MyServiceBus.Abstractions;
using MyServiceBus.TcpClient;

namespace MyJetWallet.Domain.ServiceBus.PublisherSubscriber.TradeVolumes
{
    [UsedImplicitly]
    public class TradeVolumeServiceBusSubscriber : Subscriber<TradeVolume>
    {
        public TradeVolumeServiceBusSubscriber(MyServiceBusTcpClient client, string queueName, TopicQueueType queryType, bool batchSubscribe) :
            base(client, TopicNames.PriceTradeVolume, queueName, queryType,
                bytes => bytes.ByteArrayToServiceBusContract<TradeVolume>(), batchSubscribe)
        {

        }
    }
}