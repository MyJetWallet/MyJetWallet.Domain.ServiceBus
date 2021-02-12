using System;
using System.IO;
using JetBrains.Annotations;

namespace MyJetWallet.Domain.MyServiceBus.Serializers
{
    [UsedImplicitly]
    public static class ContractToDomainMapper
    {
        [UsedImplicitly]
        public static T ByteArrayToServiceBusContract<T>(this ReadOnlyMemory<byte> data)
        {
            if (MyServiceBusContracts.IsDebug)
                Console.WriteLine($"GOT {typeof(T)} MESSAGE LEN:" + data.Length);

            var span = data.Span;

            if (span[0] == 0)
            {
                span = data.Slice(1, data.Length - 1).Span;
                var mem = new MemoryStream(data.Length);
                mem.Write(span);
                mem.Position = 0;
                return ProtoBuf.Serializer.Deserialize<T>(mem);
            }

            throw new Exception("Not supported version of Contract");
        }

    }
}