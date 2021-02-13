using System;
using System.Runtime.Serialization;

namespace MyJetWallet.Domain.ServiceBus.Models
{
    [DataContract]
    public class ClientRegistrationMessage
    {
        [DataMember(Order = 1)] public JetClientIdentity ClientId { get; set; }
        [DataMember(Order = 2)] public DateTime RegisterTime { get; set; }
    }
}