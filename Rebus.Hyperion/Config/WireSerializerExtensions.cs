using Rebus.Hyperion;
using Rebus.Serialization;
// ReSharper disable UnusedMember.Global

namespace Rebus.Config;

/// <summary>
/// Configuration extensions for the Hyperion serializer
/// </summary>
public static class HyperionSerializerConfigurationExtensions
{
    /// <summary>
    /// Configures Rebus to use the super-spiffy Hyperion serializer to serialize messages
    /// </summary>
    public static void UseHyperion(this StandardConfigurer<ISerializer> configurer)
    {
        configurer.Register(c => new HyperionSerializer(), 
            "HyperionSerializer was registered as the primary implementation of ISerializer");
    }
}