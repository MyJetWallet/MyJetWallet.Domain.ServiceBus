using System.Threading.Tasks;
using DotNetCoreDecorators;
using JetBrains.Annotations;
using MyJetWallet.Domain.MyServiceBus.Serializers;
using MyJetWallet.Domain.Prices;
using MyServiceBus.TcpClient;

namespace MyJetWallet.Domain.MyServiceBus.PublisherSubscriber.BidAsks
{
    [UsedImplicitly]
    public class BidAskMyServiceBusPublisher : IPublisher<BidAsk>
    {
        private readonly MyServiceBusTcpClient _client;

        public BidAskMyServiceBusPublisher(MyServiceBusTcpClient client)
        {
            _client = client;
            _client.CreateTopicIfNotExists(TopicNames.BidAsk, 100000);
        }

        public async ValueTask PublishAsync(BidAsk valueToPublish)
        {
            var bytesToSend = valueToPublish.ServiceBusContractToByteArray();
            await _client.PublishAsync(TopicNames.BidAsk, bytesToSend, false);
        }
    }
}