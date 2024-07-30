using System.Runtime.Serialization;

namespace Assfinet.Shared.Exceptions;

public class KundeParserServiceException : Exception
{
    public KundeParserServiceException()
    {
    }

    protected KundeParserServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public KundeParserServiceException(string? message) : base(message)
    {
    }

    public KundeParserServiceException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}