using System.Runtime.Serialization;

namespace Assfinet.Shared.Exceptions;

public class UnknownSparteException : Exception
{
    public UnknownSparteException()
    {
    }

    protected UnknownSparteException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public UnknownSparteException(string? message) : base(message)
    {
    }

    public UnknownSparteException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}