using Rebus.Serialization;
using Rebus.Tests.Contracts.Serialization;

namespace Rebus.Hyperion.Tests;

public class HyperionSerializerFactory : ISerializerFactory
{
    public ISerializer GetSerializer() => new HyperionSerializer();
}