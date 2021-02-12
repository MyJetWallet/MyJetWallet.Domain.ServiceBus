using System;
using System.IO;
using JetBrains.Annotations;

namespace MyJetWallet.Domain.ServiceBus.Serializers
{
    [UsedImplicitly]
    public static class DomainToContractMapper
    {
        [UsedImplicitly]
        public static byte[] ServiceBusContractToByteArray(this object src)
        {

            var stream = new MemoryStream();

            stream.WriteByte(0); // First byte is a version contract;

            ProtoBuf.Serializer.Serialize(stream, src);

            var result = stream.ToArray();
            
            if (MyServiceBusContracts.IsDebug)
                Console.WriteLine($"Serialize {src.GetType()} MESSAGE LEN:" + result.Length);

            return result;
        }
    }
    
}