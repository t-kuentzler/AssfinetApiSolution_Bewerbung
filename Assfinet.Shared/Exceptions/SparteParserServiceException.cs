using System.Runtime.Serialization;

namespace Assfinet.Shared.Exceptions;

public class SparteParserServiceException : Exception
{
    public SparteParserServiceException()
    {
    }

    protected SparteParserServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public SparteParserServiceException(string? message) : base(message)
    {
    }

    public SparteParserServiceException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}