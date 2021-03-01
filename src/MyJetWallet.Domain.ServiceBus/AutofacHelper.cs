using Autofac;
using DotNetCoreDecorators;
using JetBrains.Annotations;
using MyJetWallet.Domain.Prices;
using MyJetWallet.Domain.ServiceBus.Models;
using MyJetWallet.Domain.ServiceBus.PublisherSubscriber.BidAsks;
using MyJetWallet.Domain.ServiceBus.PublisherSubscriber.Registrations;
using MyJetWallet.Domain.ServiceBus.PublisherSubscriber.TradeVolumes;
using MyServiceBus.TcpClient;
// ReSharper disable UnusedMember.Global

namespace MyJetWallet.Domain.ServiceBus
{
    [UsedImplicitly]
    public static class AutofacHelper
    {
        /// <summary>
        /// Register IPublisher for ClientRegistrationMessage
        /// </summary>
        public static void RegisterClientRegistrationPublisher(this ContainerBuilder builder, MyServiceBusTcpClient client)
        {
            builder
                .RegisterInstance(new ClientRegistrationServiceBusPublisher(client))
                .As<IPublisher<ClientRegistrationMessage>>()
                .SingleInstance();
        }

        /// <summary>
        /// Register ISubscriber for ClientRegistrationMessage
        /// </summary>
        public static void RegisterClientRegistrationSubscriber(this ContainerBuilder builder, MyServiceBusTcpClient client, string queueName, bool deleteOnDisconnect)
        {
            builder
                .RegisterInstance(new ClientRegistrationServiceBusSubscriber(client, queueName, deleteOnDisconnect))
                .As<ISubscriber<ClientRegistrationMessage>>()
                .SingleInstance();
        }

        /// <summary>
        /// Register IPublisher for BidAsk
        /// </summary>
        public static void RegisterBidAskPublisher(this ContainerBuilder builder, MyServiceBusTcpClient client)
        {
            builder
                .RegisterInstance(new BidAskMyServiceBusPublisher(client))
                .As<IPublisher<BidAsk>>()
                .SingleInstance();
        }

        /// <summary>
        /// Register ISubscriber for BidAsk
        /// </summary>
        public static void RegisterBidAskSubscriber(this ContainerBuilder builder, MyServiceBusTcpClient client, string queueName, bool deleteOnDisconnect)
        {
            builder
                .RegisterInstance(new BidAskMyServiceBusSubscriber(client, queueName, deleteOnDisconnect))
                .As<ISubscriber<BidAsk>>()
                .SingleInstance();
        }

        /// <summary>
        /// Register IPublisher for TradeVolume
        /// </summary>
        public static void RegisterTradeVolumePublisher(this ContainerBuilder builder, MyServiceBusTcpClient client)
        {
            builder
                .RegisterInstance(new TradeVolumeServiceBusPublisher(client))
                .As<IPublisher<TradeVolume>>()
                .SingleInstance();
        }

        /// <summary>
        /// Register ISubscriber for BidAsk
        /// </summary>
        public static void RegisterTradeVolumeSubscriber(this ContainerBuilder builder, MyServiceBusTcpClient client, string queueName, bool deleteOnDisconnect)
        {
            builder
                .RegisterInstance(new TradeVolumeServiceBusSubscriber(client, queueName, deleteOnDisconnect))
                .As<ISubscriber<TradeVolume>>()
                .SingleInstance();
        }
    }
}