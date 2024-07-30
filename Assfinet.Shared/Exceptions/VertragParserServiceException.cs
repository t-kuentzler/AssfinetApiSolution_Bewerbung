using System.Runtime.Serialization;

namespace Assfinet.Shared.Exceptions;

public class VertragParserServiceException : Exception
{
    public VertragParserServiceException()
    {
    }

    protected VertragParserServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public VertragParserServiceException(string? message) : base(message)
    {
    }

    public VertragParserServiceException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}