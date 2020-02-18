using NUnit.Framework;
using Rebus.Activation;
using Rebus.Config;
using Rebus.Transport.InMem;

namespace Rebus.Hyperion.Tests
{
    [TestFixture]
    public class CheckApi
    {
        [Test]
        public void ThisIsWhatItLooksLike()
        {
            Configure.With(new BuiltinHandlerActivator())
                .Transport(t => t.UseInMemoryTransport(new InMemNetwork(), "doesn't matter"))
                .Serialization(s => s.UseHyperion())
                .Start();
        }
    }
}