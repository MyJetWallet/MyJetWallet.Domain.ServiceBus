using System.Threading.Tasks;
using DotNetCoreDecorators;
using JetBrains.Annotations;
using MyJetWallet.Domain.Prices;
using MyJetWallet.Domain.ServiceBus.Serializers;
using MyServiceBus.TcpClient;

namespace MyJetWallet.Domain.ServiceBus.PublisherSubscriber.BidAsks
{
    [UsedImplicitly]
    public class BidAskMyServiceBusPublisher : IPublisher<BidAsk>
    {
        private readonly MyServiceBusTcpClient _client;

        public BidAskMyServiceBusPublisher(MyServiceBusTcpClient client)
        {
            _client = client;
            _client.CreateTopicIfNotExists(TopicNames.BidAsk);
        }

        public async ValueTask PublishAsync(BidAsk valueToPublish)
        {
            var bytesToSend = valueToPublish.ServiceBusContractToByteArray();
            await _client.PublishAsync(TopicNames.BidAsk, bytesToSend, false);
        }
    }
}