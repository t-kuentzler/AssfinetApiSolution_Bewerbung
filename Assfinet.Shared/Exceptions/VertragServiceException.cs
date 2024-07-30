using System.Runtime.Serialization;

namespace Assfinet.Shared.Exceptions;

public class VertragServiceException : Exception
{
    public VertragServiceException()
    {
    }

    protected VertragServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public VertragServiceException(string? message) : base(message)
    {
    }

    public VertragServiceException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}