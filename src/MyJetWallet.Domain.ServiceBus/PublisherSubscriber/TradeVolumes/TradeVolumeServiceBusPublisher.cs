using System.Threading.Tasks;
using DotNetCoreDecorators;
using JetBrains.Annotations;
using MyJetWallet.Domain.Prices;
using MyJetWallet.Domain.ServiceBus.Serializers;
using MyServiceBus.TcpClient;

namespace MyJetWallet.Domain.ServiceBus.PublisherSubscriber.TradeVolumes
{
    [UsedImplicitly]
    public class TradeVolumeServiceBusPublisher : IPublisher<TradeVolume>
    {
        private readonly MyServiceBusTcpClient _client;

        public TradeVolumeServiceBusPublisher(MyServiceBusTcpClient client)
        {
            _client = client;
            _client.CreateTopicIfNotExists(TopicNames.PriceTradeVolume, 100000);
        }

        public async ValueTask PublishAsync(TradeVolume valueToPublish)
        {
            var bytesToSend = valueToPublish.ServiceBusContractToByteArray();
            await _client.PublishAsync(TopicNames.PriceTradeVolume, bytesToSend, false);
        }
    }
}