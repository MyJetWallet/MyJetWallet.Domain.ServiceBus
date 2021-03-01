using JetBrains.Annotations;
using MyJetWallet.Domain.Prices;
using MyJetWallet.Domain.ServiceBus.Serializers;
using MyServiceBus.TcpClient;

namespace MyJetWallet.Domain.ServiceBus.PublisherSubscriber.TradeVolumes
{
    [UsedImplicitly]
    public class TradeVolumeServiceBusSubscriber : Subscriber<TradeVolume>
    {
        public TradeVolumeServiceBusSubscriber(MyServiceBusTcpClient client, string queueName, bool deleteOnDisconnect) :
            base(client, TopicNames.PriceTradeVolume, queueName, deleteOnDisconnect,
                bytes => bytes.ByteArrayToServiceBusContract<TradeVolume>())
        {

        }
    }
}