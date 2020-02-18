using System;
using System.IO;
using System.Threading.Tasks;
using Hyperion;
using Rebus.Extensions;
using Rebus.Messages;
using Rebus.Serialization;

#pragma warning disable 1998

namespace Rebus.Hyperion
{
    /// <summary>
    /// Rebus serializer that uses the binary Hyperion serializer to provide a robust POCO serialization that supports everything that you would expect from a modern serializer
    /// </summary>
    class HyperionSerializer : ISerializer
    {
        /// <summary>
        /// Mime type for Hyperion
        /// </summary>
        public const string HyperionContentType = "application/x-hyperion";

        readonly Serializer _serializer = new Serializer();

        /// <summary>
        /// Serializes the given <see cref="Message"/> into a <see cref="TransportMessage"/> using the Hyperion format,
        /// adding a <see cref="Headers.ContentType"/> header with the value of <see cref="HyperionContentType"/>
        /// </summary>
        public async Task<TransportMessage> Serialize(Message message)
        {
            using (var destination = new MemoryStream())
            {
                _serializer.Serialize(message.Body, destination);

                var headers = message.Headers.Clone();

                headers[Headers.ContentType] = HyperionContentType;

                return new TransportMessage(headers, destination.ToArray());
            }
        }

        /// <summary>
        /// Deserializes the given <see cref="TransportMessage"/> back into a <see cref="Message"/>. Expects a
        /// <see cref="Headers.ContentType"/> header with a value of <see cref="HyperionContentType"/>, otherwise
        /// it will not attempt to deserialize the message.
        /// </summary>
        public async Task<Message> Deserialize(TransportMessage transportMessage)
        {
            var contentType = transportMessage.Headers.GetValue(Headers.ContentType);

            if (contentType != HyperionContentType)
            {
                throw new FormatException($"Unknown content type: '{contentType}' - must be '{HyperionContentType}' for the JSON serialier to work");
            }

            using (var source = new MemoryStream(transportMessage.Body))
            {
                var body = _serializer.Deserialize(source);

                return new Message(transportMessage.Headers.Clone(), body);
            }
        }
    }
}
